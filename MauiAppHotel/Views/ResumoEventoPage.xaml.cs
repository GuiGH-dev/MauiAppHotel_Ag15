
using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ResumoEventoPage : ContentPage
{
    public ResumoEventoPage(Evento evento)
    {
        InitializeComponent();

        // Associa o objeto Evento à interface.
        BindingContext = evento;
    }

    private async void NovoCadastro_Clicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}
