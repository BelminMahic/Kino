using AutoMapper;
using Kino.API.Database;
using Kino.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Services
{
    public class AuditoriumService : BaseCRUDService<Model.Auditorium, AuditoriumSearchRequest, Database.Auditorium, AuditoriumUpsertRequest, AuditoriumUpsertRequest>
    {
        public AuditoriumService(KinotekaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Auditorium> Get(AuditoriumSearchRequest request)
        {
            var query = _context.Set<Database.Auditorium>().AsQueryable();

            if (!string.IsNullOrEmpty(request?.AuditoriumName))
                query = query.Where(x => x.AuditoriumName.StartsWith(request.AuditoriumName));

            if(request?.IncludeList?.Length > 0)
            {
                foreach (var item in request.IncludeList)
                {
                    query = query.Include(item);
                }
            }

            var list = query.ToList();

            return _mapper.Map<List<Model.Auditorium>>(list); ;
        }


    }
}
