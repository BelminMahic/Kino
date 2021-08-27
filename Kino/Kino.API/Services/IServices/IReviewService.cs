using Kino.Model.Requests;
using System.Collections.Generic;

namespace Kino.API.Services.IServices
{
    public interface IReviewService
    {
        List<Model.UserMovieRating> GetRatingsByMovieId(int movieId);
        Model.UserMovieRating Insert(UserMovieRatingUpsertRequest request);
    }
}
