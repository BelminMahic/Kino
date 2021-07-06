using AutoMapper;
using Kino.API.Database;
using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Services
{
    public class CityService : BaseCRUDService<Model.City, CitySearchRequest, Database.City, CityUpsertRequest, CityUpsertRequest>
    {
        public CityService(KinotekaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override List<Model.City> Get(CitySearchRequest search)
        {
            var query = _context.Set<Database.City>().AsQueryable();

            if (search?.CountryId.HasValue == true)
            {
                query = query.Where(x => x.CountryId == search.CountryId);
            }

            query = query.OrderBy(x => x.CityName);

            var list = query.ToList();


            return _mapper.Map<List<Model.City>>(list);
        }
    }
}
