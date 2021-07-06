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

    public class GenderController : BaseCRUDController<Model.Gender, object, GenderUpsertRequest, GenderUpsertRequest>
    {
        public GenderController(ICRUDService<Gender, object, GenderUpsertRequest, GenderUpsertRequest> service) : base(service)
        {
        }
    }
}
