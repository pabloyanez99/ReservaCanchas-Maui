using ReservaCanchas_Maui.Models;
using ReservaCanchas_Maui.Repositories;

namespace ReservaCanchas_Maui.AdminViews;

public partial class GestionarCancha : ContentPage
{
    public Usuario _usuario;
    public Complejo _complejo;
    public Cancha _cancha;
    public ReservaRepositroy _repository;
    public Reserva _reserva;
    public GestionarCancha()
	{
		//InitializeComponent();
	}

    private void OnGuardarCambiosClicked(object sender, EventArgs e)
    {

    }

    private void OnRegresarClicked(object sender, EventArgs e)
    {

    }
}
