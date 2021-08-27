using AutoMapper;
using Kino.API.Database;
using Kino.API.Services.IServices;
using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Services
{
    public class ReviewService : IReviewService
    {
        private KinotekaDbContext _context;
        private readonly IMapper _mapper;

        public ReviewService(KinotekaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.UserMovieRating Insert(UserMovieRatingUpsertRequest request)
        {
            var entity = _mapper.Map<Database.UserMovieRating>(request);

            _context.UserMovieRating.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.UserMovieRating>(entity);
        }

        public List<Model.UserMovieRating> GetRatingsByMovieId(int movieId)
        {
            var entity = _context.UserMovieRating.Where(x => x.MovieId == movieId).ToList();

            return _mapper.Map<List<Model.UserMovieRating>>(entity);
        }
    }
}
