using Kino.API.Services.IServices;
using Kino.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Controllers
{
    [AllowAnonymous]
    public class RolesController : BaseController<Model.Role, object>
    {
        public RolesController(IService<Role, object> service) : base(service)
        {
        }
    }
}
