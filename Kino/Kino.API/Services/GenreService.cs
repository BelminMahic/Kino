using AutoMapper;
using Kino.API.Database;
using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Services
{
    public class GenreService : BaseCRUDService<Model.Genre, GenreSearchRequest, Database.Genre, GenreUpsertRequest, GenreUpsertRequest>
    {
        public GenreService(KinotekaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Genre> Get(GenreSearchRequest request)
        {
            var query = _context.Set<Database.Genre>().AsQueryable();

            if (!string.IsNullOrEmpty(request?.GenreName))
                query = query.Where(x => x.GenreName.StartsWith(request.GenreName));

            var list = query.ToList();

            return _mapper.Map<List<Model.Genre>>(list); ;
        }
    }
}
