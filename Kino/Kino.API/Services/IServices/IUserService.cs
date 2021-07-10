using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Services.IServices
{
    public interface IUserService
    {
        
        List<Model.User> GetUsers(UserSearchRequest request);
        Kino.Model.User GetById(int id);
        Model.User Insert(UserUpsertRequest request);
        Model.User Update(int id, UserUpsertRequest request);

        Task<Model.User> Login(string username, string password);
    }
}
