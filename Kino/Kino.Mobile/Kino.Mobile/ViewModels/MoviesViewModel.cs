using Kino.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kino.Mobile.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        private readonly APIService _movieService = new APIService("movie");

        public MoviesViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Movie> MoviesList { get; set; } = new ObservableCollection<Movie>();

        public ICommand InitCommand { get; set; }

        public async Task Init() 
        {
            var list = await _movieService.Get<IEnumerable<Movie>>(null);
            MoviesList.Clear();
            foreach (var item in list)
            {
                MoviesList.Add(item);
            }

        }
    }
}
