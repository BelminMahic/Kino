using Kino.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kino.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        private MoviesViewModel moviesViewModel = null;
        public MoviesPage()
        {
            InitializeComponent();
            BindingContext = moviesViewModel = new MoviesViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await moviesViewModel.Init();
        }
    }
}