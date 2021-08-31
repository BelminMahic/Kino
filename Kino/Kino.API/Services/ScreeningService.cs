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
    public class ScreeningService : BaseCRUDService<Model.Screening, ScreeningSearchRequest, Database.Screening, ScreeningUpsertRequest, ScreeningUpsertRequest>

    {
        public ScreeningService(KinotekaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Screening> Get(ScreeningSearchRequest search)
        {
            var query = _context.Set<Database.Screening>().AsQueryable();

            if (search?.AuditoriumId.HasValue == true)
            {
                query = query.Where(x => x.AuditoriumId == search.AuditoriumId);
            }
            if (search?.MovieId.HasValue == true)
            {
                query = query.Where(x => x.MovieId == search.MovieId);
            }

            if(search?.IncludeList?.Length > 0)
            {
                foreach (var item in search.IncludeList)
                {
                    query = query.Include(item);
                }
            }


            var list = query.ToList();


            return _mapper.Map<List<Model.Screening>>(list);
        }
    }
}
