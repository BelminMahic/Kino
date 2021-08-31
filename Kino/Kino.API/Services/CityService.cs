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
    public class CityService : BaseCRUDService<Model.City, CitySearchRequest, Database.City, CityUpsertRequest, CityUpsertRequest>
    {
        public CityService(KinotekaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override List<Model.City> Get(CitySearchRequest search)
        {
            var query = _context.Set<Database.City>().AsQueryable();

            if (!string.IsNullOrEmpty(search?.CityName))
                query = query.Where(x => x.CityName.StartsWith(search.CityName));

           
            if(search?.IncludeList?.Length > 0)
            {
                foreach (var item in search.IncludeList)
                {
                    query = query.Include(item);

                }
            }


            query = query.OrderBy(x => x.CityName);

            var list = query.ToList();


            return _mapper.Map<List<Model.City>>(list);
        }
    }
}
