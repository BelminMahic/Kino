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

    public class CountryController : BaseCRUDController<Model.Country, CountrySearchRequest, CountryUpsertRequest, CountryUpsertRequest>
    {
        public CountryController(ICRUDService<Country, CountrySearchRequest, CountryUpsertRequest, CountryUpsertRequest> service) : base(service)
        {
        }
    }
}
