using AutoMapper;
using Kino.API.Database;
using Kino.API.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kino.API.Services
{
    public class RecommendedService : IRecommenderService
    {
        private readonly IMapper _mapper;
        private KinotekaDbContext _db;
        Dictionary<int, List<Database.UserMovieRating>> movieRatings = new Dictionary<int, List<Database.UserMovieRating>>();

        public RecommendedService(KinotekaDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<Kino.Model.Movie> GetRecommendedMovies(int movieId)
        {
            LoadMovieRatings(movieId);

            List<Database.UserMovieRating> ratingsOfCurrentMovie = _db.UserMovieRating.Where(s => s.MovieId == movieId).OrderBy(s => s.UserId).ToList();


            List<Database.UserMovieRating> commonRatings1 = new List<Database.UserMovieRating>();
            List<Database.UserMovieRating> commonRatings2 = new List<Database.UserMovieRating>();

            List<Database.Movie> recommendedMovies = new List<Database.Movie>();

            foreach (var item in movieRatings)
            {
                foreach (var o in ratingsOfCurrentMovie)
                {
                    if (item.Value.Where(x => x.UserId == o.UserId).Count() > 0)
                    {
                        commonRatings1.Add(o);
                        commonRatings2.Add(item.Value.Where(x => x.UserId == o.UserId).FirstOrDefault());
                    }
                }
                double similarity = GetSimilarity(commonRatings1, commonRatings2);
                if (similarity > 0.5)
                {
                    recommendedMovies.Add(_db.Movie.Where(s => s.MovieId == item.Key).FirstOrDefault());

                }
                commonRatings1.Clear();
                commonRatings2.Clear();
            }


            //if more than 5 movies is recommended, take 5 with highest rating
            if (recommendedMovies.Count > 5)
            {
                recommendedMovies = recommendedMovies.Take(5).ToList();
            }

            return _mapper.Map<List<Model.Movie>>(recommendedMovies);
        }

        private void LoadMovieRatings(int movieId)
        {
            // get screenings that are still available to see
            var activeMovies = _db.Movie.Where(x => x.MovieId == movieId).ToList();

            List<Database.UserMovieRating> ratings;
            foreach (Database.Movie item in activeMovies)
            {
                // get ratings for movie
                ratings = _db.UserMovieRating.Where(s => s.MovieId == item.MovieId).OrderBy(x => x.UserId).ToList();
                if (ratings.Count > 0)
                {
                    movieRatings.Add(item.MovieId, ratings);
                }
            }
        }

        private double GetSimilarity(List<Database.UserMovieRating> commonRatings1, List<Database.UserMovieRating> commonRatings2)
        {
            if (commonRatings1.Count != commonRatings2.Count)
                return 0;
            double counter = 0, denominator1 = 0, denominator2 = 0;

            for (int i = 0; i < commonRatings1.Count; i++)
            {
                counter = Convert.ToDouble(commonRatings1[i].Rating * commonRatings2[i].Rating);
                denominator1 = Convert.ToDouble(commonRatings2[i].Rating * commonRatings1[i].Rating);
                denominator2 = Convert.ToDouble(commonRatings1[i].Rating * commonRatings2[i].Rating);
            }
            denominator1 = Math.Sqrt(denominator1);
            denominator2 = Math.Sqrt(denominator2);
            double denominator = denominator1 * denominator2;
            if (denominator == 0)
                return 0;
            return counter / denominator;
        }
    }
}
