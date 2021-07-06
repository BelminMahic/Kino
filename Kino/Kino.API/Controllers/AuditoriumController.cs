using Kino.API.Services.IServices;
using Kino.Model;
using Kino.Model.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Controllers
{

    public class AuditoriumController : BaseCRUDController<Model.Auditorium, AuditoriumSearchRequest, AuditoriumUpsertRequest, AuditoriumUpsertRequest>
    {
        public AuditoriumController(ICRUDService<Auditorium, AuditoriumSearchRequest, AuditoriumUpsertRequest, AuditoriumUpsertRequest> service) : base(service)
        {
        }
    }
}
