using Kino.API.Database;
using Kino.API.Filters;
using Kino.API.Security;
using Kino.API.Services;
using Kino.API.Services.IServices;
using Kino.Model.Requests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace Kino.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(x =>
                x.Filters.Add<ErrorFilter>()
            ).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            });


            services.AddDbContext<KinotekaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("kinoteka")));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("KinotekaOpenAPISpec",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Kinoteka API",
                        Version = "1"
                    });
                options.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
                        },
                        new string[]{}
                    }
                });
            });


            services.AddAutoMapper(typeof(KinotekaDbContext));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IRecommenderService, RecommendedService>();

            services.AddScoped<IService<Model.Role, object>, BaseService<Model.Role, object, Role>>();
            services.AddScoped<ICRUDService<Model.Country, CountrySearchRequest, CountryUpsertRequest, CountryUpsertRequest>, CountryService>();
            services.AddScoped<ICRUDService<Model.City, CitySearchRequest, CityUpsertRequest, CityUpsertRequest>, CityService>();
            services.AddScoped<ICRUDService<Model.Genre, GenreSearchRequest, GenreUpsertRequest, GenreUpsertRequest>, GenreService>();
            services.AddScoped<ICRUDService<Model.Gender, object, GenderUpsertRequest, GenderUpsertRequest>, GenderService>();
            services.AddScoped<ICRUDService<Model.Cinema, CinemaSearchRequest, CinemaUpsertRequest, CinemaUpsertRequest>, CinemaService>();
            services.AddScoped<ICRUDService<Model.PromoMaterial, PromoMaterialSearchRequest, PromoMaterialUpsertRequest, PromoMaterialUpsertRequest>, PromoMaterialService>();
            services.AddScoped<ICRUDService<Model.Screening, ScreeningSearchRequest, ScreeningUpsertRequest, ScreeningUpsertRequest>, ScreeningService>();
            services.AddScoped<ICRUDService<Model.Auditorium, AuditoriumSearchRequest, AuditoriumUpsertRequest, AuditoriumUpsertRequest>, AuditoriumService>();
            services.AddScoped<ICRUDService<Model.Movie, MovieSearchRequest, MovieUpsertRequest, MovieUpsertRequest>, MovieService>();
            services.AddScoped<ICRUDService<Model.MovieSeat, MovieSeatSearchRequest, MovieSeatUpsertRequest, MovieSeatUpsertRequest>, MovieSeatService>();
            services.AddScoped<ICRUDService<Model.Reservation, ReservationSearchRequest, ReservationUpsertRequest, ReservationUpsertRequest>, ReservationService>();
            services.AddScoped<ICRUDService<Model.SeatReservation, SeatReservationSearchRequest, SeatReservationUpsertRequest, SeatReservationUpsertRequest>, SeatReservationService>();
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication",null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/KinotekaOpenAPISpec/swagger.json", "Kinoteka API");
                options.RoutePrefix = "";
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
