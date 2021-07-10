using AutoMapper;
using Kino.API.Database;
using Kino.API.Filters;
using Kino.API.Services.IServices;
using Kino.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kino.API.Services
{
    public class UserService : IUserService
    {
        private readonly KinotekaDbContext _context;
        private readonly IMapper _mapper;

        public UserService(KinotekaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);


            return Convert.ToBase64String(inArray);


        }


        public Model.User GetById(int id)
        {
            var entity = _context.User.Find(id);

            return _mapper.Map<Model.User>(entity);
        }

        public List<Model.User> GetUsers(UserSearchRequest request)
        {
            var query = _context.User.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.Name))
                query = query.Where(x => x.Name.StartsWith(request.Name));
            if (!string.IsNullOrWhiteSpace(request?.LastName))
                query = query.Where(x => x.LastName.StartsWith(request.LastName));
            if (!request?.AreRolesLoadingEnabled == true)
                query = query.Include(x => x.UserRole);

            var list = query.ToList();
            return _mapper.Map<List<Model.User>>(list);
        }

        public async Task<Model.User> Login(string username,string password)
        {
            var entity = await _context.User.Include("UserRole.Role").FirstOrDefaultAsync(x => x.UserName == username);

            if(entity == null)
            {
                throw new UserException("Pogresan username ili password");
            }
            var hash = GenerateHash(entity.PasswordSalt, password);
            if(hash != entity.PasswordHash)
            {
                throw new UserException("Pogresan username ili password");

            }


            return _mapper.Map<Model.User>(entity);
        }

        public Model.User Insert(UserUpsertRequest request)
        {
            var entity = _mapper.Map<Database.User>(request);
            if (request.Password != request.PasswordConfirmation)
            {
                throw new UserException("Passwordi se ne slazu!");
            }
            entity.PasswordSalt = GenerateSalt();

            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            _context.User.Add(entity);
            _context.SaveChanges();

            foreach (var role in request.Roles)
            {
                _context.UserRole.Add(new Database.UserRole()
                {
                    Changed = DateTime.Now,
                    UserId = entity.UserId,
                    RoleId = role
                });
            }
            _context.SaveChanges();

            return _mapper.Map<Model.User>(entity);
        }

        public Model.User Update(int id, UserUpsertRequest request)
        {
            var entity = _context.User.Find(id);
            _context.User.Attach(entity);
            _context.User.Add(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.User>(entity);
        }
    }
}
