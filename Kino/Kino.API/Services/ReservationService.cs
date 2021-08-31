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
    public class ReservationService : BaseCRUDService<Model.Reservation, ReservationSearchRequest, Database.Reservation, ReservationUpsertRequest, ReservationUpsertRequest>
    {
        public ReservationService(KinotekaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Reservation> Get(ReservationSearchRequest search)
        {
            var query = _context.Set<Database.Reservation>().AsQueryable();

            if (search?.AuditoriumId.HasValue == true)
            {
                query = query.Where(x => x.AuditoriumId == search.AuditoriumId);
            }
            if (search?.PromoMaterialId.HasValue == true)
            {
                query = query.Where(x => x.PromoMaterialId == search.PromoMaterialId);
            }

            if (search?.ScreeningId.HasValue == true)
            {
                query = query.Where(x => x.ScreeningId == search.ScreeningId);
            }

            if (search?.UserId.HasValue == true)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }

            if(search?.IncludeList?.Length > 0)
            {
                foreach (var item in search.IncludeList)
                {
                    query = query.Include(item);
                }
            }


            var list = query.ToList();


            return _mapper.Map<List<Model.Reservation>>(list);
        }
    }
}
