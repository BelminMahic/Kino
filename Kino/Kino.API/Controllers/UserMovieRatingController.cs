using Kino.API.Services.IServices;
using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Controllers
{
    public class UserMovieRatingController : BaseCRUDController<Model.UserMovieRating, UserMovieRatingSearchRequest, UserMovieRatingUpsertRequest, UserMovieRatingUpsertRequest>
    {
        public UserMovieRatingController(ICRUDService<Model.UserMovieRating, UserMovieRatingSearchRequest, UserMovieRatingUpsertRequest, UserMovieRatingUpsertRequest> service) : base(service)
        {
        }
    }
}
