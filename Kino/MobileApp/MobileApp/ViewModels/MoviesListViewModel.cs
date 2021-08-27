using MobileApp.Helpers;
using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class MoviesListViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("movie");

        private readonly APIService _recommendedService = new APIService("recommender");

        private readonly APIService _ratingsService = new APIService("usermovierating");

        private readonly APIService _reservationService = new APIService("reservation");

        private readonly APIService _screeningService = new APIService("screening");

        private ObservableCollection<Movie> _movies;

        private ObservableCollection<Movie> _recommendedMovies;

        private bool _hasMovies = false;

        private bool _isLoading = true;

        private bool _hasRecommendedMovies = false;

        public MoviesListViewModel()
        {

        }

        public ObservableCollection<Movie> RecommendedMovies
        {
            get
            {
                return _recommendedMovies;
            }
            set
            {
                SetProperty(ref _recommendedMovies, value);
            }
        }

        public ObservableCollection<Movie> Movies
        {
            get
            {
                return _movies;
            }
            set
            {
                SetProperty(ref _movies, value);
            }
        }

        public bool HasMovies
        {
            get
            {
                return _hasMovies;
            }
            set
            {
                SetProperty(ref _hasMovies, value);
            }
        }

        public bool HasRecommendedMovies
        {
            get
            {
                return _hasRecommendedMovies;
            }
            set
            {
                SetProperty(ref _hasRecommendedMovies, value);
            }
        }

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                SetProperty(ref _isLoading, value);
            }
        }

        public async Task InitializeData()
        {
            try
            {
                IsLoading = true;

                var request = new Kino.Model.Requests.ReservationSearchRequest
                {
                    UserId = Settings.UserId
                };
                // get all reservations by user
                var previousMovies = await _reservationService.Get<List<Models.Reservation>>(request);

                // order from newest to oldest reservation
                var orderedScreenings = previousMovies.OrderByDescending(x => x.ReservationDate).ToList();

                // get last movie user watched
                var screening = await _screeningService.GetById<Models.Screening>(orderedScreenings?.FirstOrDefault()?.ScreeningId);


                var recommendedMoviesList = await _recommendedService.GetById<List<Kino.Model.Movie>>(screening?.MovieId);
                RecommendedMovies = new ObservableCollection<Movie>(ConvertMovies(recommendedMoviesList.Where(x => x.ShowTime >= DateTime.Now).ToList()));

                var moviesList = await _service.Get<List<Kino.Model.Movie>>(null);
                Movies = new ObservableCollection<Movie>(ConvertMovies(moviesList.Where(x => x.ShowTime >= DateTime.Now).ToList()));

                var tempMovies = new List<Models.Movie>();
                foreach (var movie in Movies.ToList())
                {
                    var ratings = await _ratingsService.GetById<List<Kino.Model.UserMovieRating>>(movie.MovieId);
                    if (ratings?.Any() ?? false)
                    {
                        movie.AverageRating = ratings.Average(x => x.Rating);
                    }
                    tempMovies.Add(movie);
                }

                Movies = new ObservableCollection<Movie>(tempMovies);

                tempMovies = new List<Movie>();
                foreach (var movie in RecommendedMovies.ToList())
                {
                    var ratings = await _ratingsService.GetById<List<Kino.Model.UserMovieRating>>(movie.MovieId);
                    if (ratings?.Any() ?? false)
                    {
                        movie.AverageRating = ratings.Average(x => x.Rating);
                    }
                    tempMovies.Add(movie);
                }

                RecommendedMovies = new ObservableCollection<Movie>(tempMovies);

                HasMovies = Movies?.Count > 0;
                HasRecommendedMovies = _recommendedMovies?.Count > 0;
            }
            catch (Exception ex)
            {
                HasRecommendedMovies = false;
                HasMovies = false;
                await Application.Current.MainPage.DisplayAlert("Greska!",
                                                            "Doslo je do greske. Pokusajte kasnije.",
                                                            "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private List<Movie> ConvertMovies(List<Kino.Model.Movie> moviesList)
        {
            var movies = new List<Movie>();
            foreach (var movie in moviesList)
            {
                movies.Add(new Movie
                {
                    MovieId = movie.MovieId,
                    MovieName = movie.MovieName,
                    OriginalMovieName = movie.OriginalMovieName,
                    DirectorFullName = movie.DirectorFullName,
                    ActorsName = movie.ActorsName,
                    MovieDuration = movie.MovieDuration,
                    ShowTime = movie.ShowTime,
                    Description = movie.Description,
                    GenreId = movie.GenreId,
                    CinemaId = movie.CinemaId,
                    MoviePoster = movie.MoviePoster,
                    ImageSource = ImageSource.FromStream(() => { return new MemoryStream(movie.MoviePoster); })
                });
            }

            return movies;
        }
    }
}
