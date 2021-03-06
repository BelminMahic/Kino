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
    public class MovieService : BaseCRUDService<Model.Movie, MovieSearchRequest, Database.Movie, MovieUpsertRequest, MovieUpsertRequest>
    {
        public MovieService(KinotekaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Movie> Get(MovieSearchRequest request)
        {
            var query = _context.Set<Database.Movie>().AsQueryable();

            if (!string.IsNullOrEmpty(request?.MovieName))
                query = query.Where(x => x.MovieName.StartsWith(request.MovieName));

            if(request?.IncludeList?.Length > 0)
            {
                foreach (var item in request.IncludeList)
                {

                    query = query.Include(item);
                }
            }

            var list = query.ToList();

            return _mapper.Map<List<Model.Movie>>(list); 
        }
    }
}
