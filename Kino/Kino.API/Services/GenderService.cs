using AutoMapper;
using Kino.API.Database;
using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Services
{
    public class GenderService : BaseCRUDService<Model.Gender, object, Database.Gender, GenderUpsertRequest, GenderUpsertRequest>
    {
        public GenderService(KinotekaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
