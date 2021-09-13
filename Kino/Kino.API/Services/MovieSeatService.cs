using AutoMapper;
using Kino.API.Database;
using Kino.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Services
{
    public class MovieSeatService : BaseCRUDService<Model.MovieSeat, MovieSeatSearchRequest, Database.MovieSeat, MovieSeatUpsertRequest, MovieSeatUpsertRequest>
    {
        public MovieSeatService(KinotekaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.MovieSeat> Get(MovieSeatSearchRequest request)
        {
            var query = _context.Set<Database.MovieSeat>().AsQueryable();

            if (request?.AuditoriumId.HasValue == true)
            {
                query = query.Where(x => x.AuditoriumId == request.AuditoriumId);
            }


            if (request?.IncludeList?.Length > 0)
            {
                foreach (var item in request.IncludeList)
                {

                    query = query.Include(item);
                }
            }

            var list = query.ToList();

            return _mapper.Map<List<Model.MovieSeat>>(list); 
        }
    }
}
