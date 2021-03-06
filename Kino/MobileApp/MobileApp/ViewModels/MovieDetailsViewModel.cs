using Kino.Model;
using Kino.Model.Requests;
using MobileApp.Helpers;
using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class MovieDetailsViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("screening");
        private readonly APIService _auditoriumService = new APIService("auditorium");
        private readonly APIService _ratingService = new APIService("usermovierating");

        private Models.Movie _movie;

        private ObservableCollection<Models.Screening> _allScreenings;

        private ObservableCollection<Models.Screening> _todaysScreenings;

        private bool _isLoading = true;

        private int _rate = 1;

        public MovieDetailsViewModel(Models.Movie movie)
        {
            _movie = movie;
        }

        public Models.Movie Movie
        {
            get
            {
                return _movie;
            }
            set
            {
                SetProperty(ref _movie, value);
            }
        }

        public ObservableCollection<Models.Screening> Screening
        {
            get
            {
                return _todaysScreenings;
            }
            set
            {
                SetProperty(ref _todaysScreenings, value);
            }
        }

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                SetProperty(ref _isLoading, value);
            }
        }

        public int Rate
        {
            get
            {
                return _rate;
            }
            set
            {
                SetProperty(ref _rate, value);
            }
        }

        public async Task InitializeData()
        {
            try
            {
                IsLoading = true;
                _allScreenings = new ObservableCollection<Models.Screening>(await _service.Get<List<Models.Screening>>(new ScreeningSearchRequest { MovieId = _movie.MovieId }));

                if (_allScreenings == null){
                    await Application.Current.MainPage.DisplayAlert("Greska!",
                                                            "Doslo je do greske. Pokusajte kasnije.",
                                                            "OK");
                    return;
                }

                foreach (var screening in _allScreenings)
                {
                    screening.Auditorium = new Models.Auditorium();
                    screening.Auditorium = await _auditoriumService.GetById<Models.Auditorium>(screening.AuditoriumId);
                    screening.Movie = _movie;
                }

                Screening = new ObservableCollection<Models.Screening>(_allScreenings.Where(x => x.ScreeningStart.Date == DateTime.Now.Date));
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Greska!",
                                                            "Doslo je do greske. Pokusajte kasnije.",
                                                            "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }

        public ObservableCollection<Models.Screening> GetAllScreenings()
        {
            return _allScreenings;
        }

        public async Task SaveRating()
        {
            try
            {
                var rate = new UserMovieRatingUpsertRequest
                {
                    UserId = Settings.UserId,
                    MovieId = _movie.MovieId,
                    Rating = _rate
                };

                var rating = await _ratingService.Insert<Kino.Model.UserMovieRating>(rate);

                if (rating == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Greska",
                                                                "Doslo je do greske. Molimo pokusajte ponovo.",
                                                                "OK");
                    return;
                }

                await Application.Current.MainPage.DisplayAlert("Uspjesno",
                                                                "Uspjesno ste ocijenili film.",
                                                                "OK");
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Greska",
                                                                "Doslo je do greske. Molimo pokusajte ponovo.",
                                                                "OK");
            }
        }
    }
}
