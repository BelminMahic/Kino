using Kino.API.Database;
using Kino.API.Services.IServices;
using Kino.Model.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Controllers
{

    public class SeatReservationController : BaseCRUDController<Model.SeatReservation, SeatReservationSearchRequest, SeatReservationUpsertRequest, SeatReservationUpsertRequest>
    {
        public SeatReservationController(ICRUDService<Model.SeatReservation, SeatReservationSearchRequest, SeatReservationUpsertRequest, SeatReservationUpsertRequest> service) : base(service)
        {
        }
    }
}
