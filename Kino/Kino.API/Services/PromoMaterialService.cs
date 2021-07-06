using AutoMapper;
using Kino.API.Database;
using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Services
{
    public class PromoMaterialService : BaseCRUDService<Model.PromoMaterial, PromoMaterialSearchRequest, Database.PromoMaterial, PromoMaterialUpsertRequest, PromoMaterialUpsertRequest>
    {
        public PromoMaterialService(KinotekaDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.PromoMaterial> Get(PromoMaterialSearchRequest request)
        {
            var query = _context.Set<Database.PromoMaterial>().AsQueryable();

            if (!string.IsNullOrEmpty(request?.PromoMaterialName))
                query = query.Where(x => x.PromoMaterialName.StartsWith(request.PromoMaterialName));

            var list = query.ToList();

            return _mapper.Map<List<Model.PromoMaterial>>(list); ;
        }
    }
}
