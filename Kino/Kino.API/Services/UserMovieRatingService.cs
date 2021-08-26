using AutoMapper;
using Kino.API.Database;
using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Services
{
    public class UserMovieRatingService : BaseCRUDService<Model.UserMovieRating, UserMovieRatingSearchRequest, Database.UserMovieRating, UserMovieRatingUpsertRequest, UserMovieRatingUpsertRequest>
    {
        public UserMovieRatingService(KinotekaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.UserMovieRating> Get(UserMovieRatingSearchRequest search)
        {
            var query = _context.Set<Database.UserMovieRating>().AsQueryable();

            if (search?.UserMovieRatingId.HasValue == true)
            {
                query = query.Where(x => x.UserMovieRatingId == search.UserMovieRatingId);
            }
            if (search?.MovieId.HasValue == true)
            {
                query = query.Where(x => x.MovieId == search.MovieId);
            }

            if (search?.UserId.HasValue == true)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }

            var list = query.ToList();


            return _mapper.Map<List<Model.UserMovieRating>>(list);
        }
    }
}
