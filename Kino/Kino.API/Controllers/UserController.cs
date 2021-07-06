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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<Model.User>> GetUsers([FromQuery] UserSearchRequest request)
        {
            return _userService.GetUsers(request);
        }
        [HttpPost]
        public Model.User Insert(UserUpsertRequest request)
        {
            return _userService.Insert(request);
        }
        [HttpPut("{id}")]

        public Model.User Update(int id, [FromBody] UserUpsertRequest request)
        {
            return _userService.Update(id, request);
        }

        [HttpGet("{id}")]
        public Model.User GetById(int id)
        {
            return _userService.GetById(id);
        }
    }
}
