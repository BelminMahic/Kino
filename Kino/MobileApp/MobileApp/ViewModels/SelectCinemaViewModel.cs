using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApp.ViewModels
{
    public class SelectCinemaViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("cinema");

        private ObservableCollection<Models.Screening> _screenings;

        private ObservableCollection<Kino.Model.Cinema> _cinemas;

        private ObservableCollection<DateTime> _availableDates;

        private ObservableCollection<DateTime> _showTimes;

        private Kino.Model.Cinema _selectedCinema;

        private DateTime _selectedDate;

        private DateTime _selectedTime;

        private Models.Movie _movie;

        public SelectCinemaViewModel(ObservableCollection<Models.Screening> screenings, Models.Movie movie)
        {
            _screenings = new ObservableCollection<Models.Screening>(screenings);
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

        public ObservableCollection<Models.Screening> Screenings
        {
            get
            {
                return _screenings;
            }
            set
            {
                SetProperty(ref _screenings, value);
            }
        }

        public ObservableCollection<Kino.Model.Cinema> Cinemas
        {
            get
            {
                return _cinemas;
            }
            set
            {
                SetProperty(ref _cinemas, value);
            }
        }

        public ObservableCollection<DateTime> AvailableDates
        {
            get
            {
                return _availableDates;
            }
            set
            {
                SetProperty(ref _availableDates, value);
            }
        }

        public ObservableCollection<DateTime> ShowTimes
        {
            get
            {
                return _showTimes;
            }
            set
            {
                SetProperty(ref _showTimes, value);
            }
        }

        public Kino.Model.Cinema SelectedCinema
        {
            get
            {
                return _selectedCinema;
            }
            set
            {
                SetProperty(ref _selectedCinema, value);
            }
        }

        public DateTime SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                SetProperty(ref _selectedDate, value);
            }
        }

        public DateTime SelectedTime
        {
            get
            {
                return _selectedTime;
            }
            set
            {
                SetProperty(ref _selectedTime, value);
            }
        }

        public bool IsSelected
        {
            get
            {
                return SelectedCinema != null && SelectedDate != DateTime.MinValue;
            }
        }

        public async Task InitializeData()
        {
            _cinemas = new ObservableCollection<Kino.Model.Cinema>();
            _availableDates = new ObservableCollection<DateTime>();
            _showTimes = new ObservableCollection<DateTime>();

            foreach (var screening in _screenings)
            {
                var cinema = await _service.GetById<Kino.Model.Cinema>(screening.Auditorium.CinemaId).ConfigureAwait(false);
                var duplicateItem = _cinemas.FirstOrDefault(x => x.CinemaId == cinema.CinemaId);
                if (duplicateItem == null)
                {
                    _cinemas.Add(cinema);
                }

                if (!_availableDates.Any(x => x.Date == screening.ScreeningStart.Date))
                {
                    _availableDates.Add(screening.ScreeningStart);
                }
            }
        }

        public void SetShowTimes()
        {
            ShowTimes = new ObservableCollection<DateTime>();

            foreach(var screening in _screenings.Where(x => x.ScreeningStart.Date == SelectedDate.Date).ToList())
            {
                ShowTimes.Add(screening.ScreeningStart);
            }

            OnPropertyChanged(nameof(IsSelected));
        }

        public Models.Screening GetScreening()
        {
            var screening = _screenings.Where(x => x.ScreeningStart == SelectedTime).FirstOrDefault();

            return screening;
        }
    }
}
