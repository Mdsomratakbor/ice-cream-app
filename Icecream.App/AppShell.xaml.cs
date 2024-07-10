using Icecream.App.Pages;

namespace Icecream.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();

        }

        private readonly static Type[] _routablePageType =
            [ 
                typeof(SignInPage),
                typeof(SignUpPage),
                typeof(MyOrderPage),
                typeof(OrderDetailsPage),
                typeof(DetailsPage)
            ];

        private void RegisterRoutes()
        {
            foreach (var type in _routablePageType)
            {
                Routing.RegisterRoute(type.Name, type);
            }
        }

        private async void FlyOutFooter_Tapped(object sender, TappedEventArgs e)
        {
            await Launcher.OpenAsync("https://www.youtube.com");
        }
    }
}
