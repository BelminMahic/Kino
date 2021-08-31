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
    public class CinemaService : BaseCRUDService<Model.Cinema, CinemaSearchRequest, Database.Cinema, CinemaUpsertRequest, CinemaUpsertRequest>
    {
        public CinemaService(KinotekaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Cinema> Get(CinemaSearchRequest request)
        {
            var query = _context.Set<Database.Cinema>().AsQueryable();

            if (!string.IsNullOrEmpty(request?.CinemaName))
                query = query.Where(x => x.CinemaName.StartsWith(request.CinemaName));

            if(request?.IncludeList?.Length > 0)
            {
                foreach (var item in request.IncludeList)
                {
                    query = query.Include(item);
                }
            }

            var list = query.ToList();

            return _mapper.Map<List<Model.Cinema>>(list); ;
        }
    }
}
