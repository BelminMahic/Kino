using AutoMapper;
using Kino.API.Database;
using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Services
{
    public class CountryService : BaseCRUDService<Model.Country, CountrySearchRequest, Database.Country, CountryUpsertRequest, CountryUpsertRequest>
    {
        public CountryService(KinotekaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Country> Get(CountrySearchRequest request)
        {
            var query = _context.Set<Database.Country>().AsQueryable();

            if (!string.IsNullOrEmpty(request?.CountryName))
                query = query.Where(x => x.CountryName.StartsWith(request.CountryName));

            var list = query.ToList();

            return _mapper.Map<List<Model.Country>>(list); ;
        }

    }
}
