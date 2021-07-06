using Kino.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Kino.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}