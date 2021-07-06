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

    public class ScreeningController : BaseCRUDController<Model.Screening, ScreeningSearchRequest, ScreeningUpsertRequest, ScreeningUpsertRequest>

    {
        public ScreeningController(ICRUDService<Model.Screening, ScreeningSearchRequest, ScreeningUpsertRequest, ScreeningUpsertRequest> service) : base(service)
        {
        }
    }
}
