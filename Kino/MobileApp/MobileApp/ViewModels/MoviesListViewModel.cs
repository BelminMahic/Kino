using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class MoviesListViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("movie");

        private ObservableCollection<Movie> _movies;

        private bool _hasMovies = true;

        private bool _isLoading = true;

        public MoviesListViewModel()
        {

        }

        public ObservableCollection<Movie> Movies
        {
            get
            {
                return _movies;
            }
            set
            {
                SetProperty(ref _movies, value);
            }
        }

        public bool HasMovies
        {
            get
            {
                return _hasMovies;
            }
            set
            {
                SetProperty(ref _hasMovies, value);
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

        public async Task InitializeData()
        {
            try
            {
                IsLoading = true;
                var moviesList = await _service.Get<List<Kino.Model.Movie>>(null);
                Movies = new ObservableCollection<Movie>();
                foreach (var movie in moviesList)
                {
                    Movies.Add(new Movie
                    {
                        MovieId = movie.MovieId,
                        MovieName = movie.MovieName,
                        OriginalMovieName = movie.OriginalMovieName,
                        DirectorFullName = movie.DirectorFullName,
                        ActorsName = movie.ActorsName,
                        MovieDuration = movie.MovieDuration,
                        ShowTime = movie.ShowTime,
                        Description = movie.Description,
                        GenreId = movie.GenreId,
                        CinemaId = movie.CinemaId,
                        MoviePoster = movie.MoviePoster,
                        ImageSource = ImageSource.FromStream(() => { return new MemoryStream(movie.MoviePoster); })
                    });
                }

                HasMovies = Movies?.Count > 0;
            }
            catch (Exception ex)
            {
                HasMovies = false;
                await Application.Current.MainPage.DisplayAlert("Greska!",
                                                            "Doslo je do greske. Pokusajte kasnije.",
                                                            "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
