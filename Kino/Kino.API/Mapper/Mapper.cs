using AutoMapper;
using Kino.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Mapper
{
    public class Mapper : Profile
    {
        public Mapper() { 
            CreateMap<Database.User, Model.User>().ReverseMap();
            CreateMap<Database.User, UserUpsertRequest>().ReverseMap();
            CreateMap<Database.Role, Model.Role>().ReverseMap();
            CreateMap<Database.UserRole, Model.UserRole>().ReverseMap();

            CreateMap<Database.Country, Model.Country>().ReverseMap();
            CreateMap<Database.Country, CountryUpsertRequest>().ReverseMap();
            CreateMap<Database.City, Model.City>().ReverseMap();
            CreateMap<Database.City, CityUpsertRequest>().ReverseMap();
            CreateMap<Database.Cinema, Model.Cinema>().ReverseMap();
            CreateMap<Database.Cinema, CinemaUpsertRequest>().ReverseMap();
            CreateMap<Database.Auditorium, Model.Auditorium>().ReverseMap();
            CreateMap<Database.Auditorium, AuditoriumUpsertRequest>().ReverseMap();
            CreateMap<Database.Gender, Model.Gender>().ReverseMap();
            CreateMap<Database.Gender, GenderUpsertRequest>().ReverseMap();
            CreateMap<Database.Genre, Model.Genre>().ReverseMap();
            CreateMap<Database.Genre, GenreUpsertRequest>().ReverseMap();
            CreateMap<Database.Movie, Model.Movie>().ReverseMap();
            CreateMap<Database.Movie, MovieUpsertRequest>().ReverseMap();
            CreateMap<Database.MovieSeat, Model.MovieSeat>().ReverseMap();
            CreateMap<Database.MovieSeat, MovieSeatUpsertRequest>().ReverseMap();
            CreateMap<Database.PromoMaterial, Model.PromoMaterial>().ReverseMap();
            CreateMap<Database.PromoMaterial, PromoMaterialUpsertRequest>().ReverseMap();
            CreateMap<Database.Reservation, Model.Reservation>().ReverseMap();
            CreateMap<Database.Reservation, ReservationUpsertRequest>().ReverseMap();
            CreateMap<Database.SeatReservation, Model.SeatReservation>().ReverseMap();
            CreateMap<Database.SeatReservation, SeatReservationUpsertRequest>().ReverseMap();
            CreateMap<Database.Screening, Model.Screening>().ReverseMap();
            CreateMap<Database.Screening, ScreeningUpsertRequest>().ReverseMap();
            CreateMap<Database.UserMovieRating, UserMovieRatingUpsertRequest>().ReverseMap();
            CreateMap<Database.UserMovieRating, Model.UserMovieRating>().ReverseMap();
        }
    }
}
