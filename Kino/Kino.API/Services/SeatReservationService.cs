using AutoMapper;
using Kino.API.Database;
using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Services
{
    public class SeatReservationService : BaseCRUDService<Model.SeatReservation, SeatReservationSearchRequest, Database.SeatReservation, SeatReservationUpsertRequest, SeatReservationUpsertRequest>
    {
        public SeatReservationService(KinotekaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.SeatReservation> Get(SeatReservationSearchRequest search)
        {
            var query = _context.Set<Database.SeatReservation>().AsQueryable();

            if (search?.MovieSeatId.HasValue == true)
            {
                query = query.Where(x => x.MovieSeatId == search.MovieSeatId);
            }

            if (search?.ReservationId.HasValue == true)
            {
                query = query.Where(x => x.ReservationId == search.ReservationId);
            }

            if (search?.ScreeningId.HasValue == true)
            {
                query = query.Where(x => x.ScreeningId == search.ScreeningId);
            }


            var list = query.ToList();


            return _mapper.Map<List<Model.SeatReservation>>(list);
        }
    }
}
