using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Utils
{
    public static class NavigationService
    {
        public static Task NavigateWithStackReset(INavigation navigation, Page pageToNavigate)
        {
            navigation.PushAsync(pageToNavigate);

            foreach (var page in navigation.NavigationStack.Where(x => x != pageToNavigate).ToList())
            {
                navigation.RemovePage(page);
            }

            return Task.CompletedTask;
        }
    }
}
