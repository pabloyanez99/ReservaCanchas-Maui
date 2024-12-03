namespace ReservaCanchas_Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.ComplejosPage), typeof(Views.ComplejosPage));
        }
    }
}
