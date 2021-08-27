using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Services.IServices
{
    public interface IRecommenderService
    {
        List<Kino.Model.Movie> GetRecommendedMovies(int movieId);
    }
}
