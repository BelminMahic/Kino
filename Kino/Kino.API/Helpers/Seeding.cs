using Kino.API.Database;
using Kino.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Helpers
{
    public class Seeding
    {
        public static void SeedDatabase(KinotekaDbContext context)
        {
            if (context.Role.Count() == 0)
            {
                var type = new List<Role>
                {
                    new Role { Name = "Admin"}
                };
                foreach (var item in type)
                {
                    context.Role.Add(item);
                }
                context.SaveChanges();
            }
            if (context.Gender.Count() == 0)
            {
                var type = new List<Gender>
                {
                    new Gender { GenderName = "M"},
                    new Gender { GenderName = "Ž"},

                };
                foreach (var item in type)
                {
                    context.Gender.Add(item);
                }
                context.SaveChanges();
            }
            if (context.User.Count() == 0)
            {
                var salt = UserService.GenerateSalt();
                var passHash = UserService.GenerateHash(salt, "test");
                var type = new List<User>
                {
                    new User { Name="Admin", LastName="Admin", UserName="admin", PasswordHash =passHash ,PasswordSalt = salt,Email="admin123@hotmail.com",GenderId=1,Phone="063/111-222",Status=true},
                    new User { Name="Belmin", LastName="Mahic", UserName="belmin.mahic", PasswordHash =passHash ,PasswordSalt = salt,Email="belmin96@windowslive.com",GenderId=1,Phone="063/111-222",Status=true},
                    new User { Name="John", LastName="Doe", UserName="john.doe", PasswordHash =passHash ,PasswordSalt = salt,Email="john.doe@hotmail.com",GenderId=1,Phone="063/111-222",Status=true}
                };

                foreach (var item in type)
                {
                    context.User.Add(item);
                }
                context.SaveChanges();
            }
            if (context.UserRole.Count() == 0)
            {
                var type = new List<UserRole>
                {
                    new UserRole {UserId=1, Changed=DateTime.Now, RoleId=1}
                };
                foreach (var item in type)
                {
                    context.UserRole.Add(item);
                }
                context.SaveChanges();
            }
        }
    }
}