using Kino.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommenderController : ControllerBase
    {
        private readonly IRecommenderService _recommenderService;
        public RecommenderController(IRecommenderService recommenderService)
        {
            _recommenderService = recommenderService;
        }

        [HttpGet("{movieId}")]
        public List<Model.Movie> GetRecommendedMovies(int movieId)
        {
            return _recommenderService.GetRecommendedMovies(movieId);
        }
    }
}
