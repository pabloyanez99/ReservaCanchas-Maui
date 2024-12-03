using ReservaCanchas_Maui.AdminViews;
using ReservaCanchas_Maui.Views;

namespace ReservaCanchas_Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
