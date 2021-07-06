using AutoMapper;
using Kino.API.Database;
using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Services
{
    public class MovieSeatService : BaseCRUDService<Model.MovieSeat, object, Database.MovieSeat, MovieSeatUpsertRequest, MovieSeatUpsertRequest>
    {
        public MovieSeatService(KinotekaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
