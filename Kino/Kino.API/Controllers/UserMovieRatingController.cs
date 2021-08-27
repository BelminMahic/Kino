using Kino.API.Services.IServices;
using Kino.Model.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kino.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMovieRatingController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public UserMovieRatingController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public Model.UserMovieRating Insert(UserMovieRatingUpsertRequest request)
        {
            return _reviewService.Insert(request);
        }

        [HttpGet("{movieId}")]
        public List<Model.UserMovieRating> GetRatingsByMovieId(int movieId)
        {
            return _reviewService.GetRatingsByMovieId(movieId);
        }
    }
}
