
using MauiAppHotel.Models;
using System.Globalization;

namespace MauiAppHotel.Views;

public partial class CadastroEventoPage : ContentPage
{
    public CadastroEventoPage()
    {
        InitializeComponent();

        dtInicio.Date = DateTime.Today;
        dtInicio.MinimumDate = DateTime.Today;

        dtTermino.Date = DateTime.Today.AddDays(1);
        dtTermino.MinimumDate = DateTime.Today.AddDays(1);

        AtualizarParticipantes();
    }

    private void AtualizarParticipantes()
    {
        int quantidade = (int)stpParticipantes.Value;

        lblParticipantes.Text = quantidade == 1
            ? "1 participante"
            : $"{quantidade} participantes";
    }

    private void Stepper_ValueChanged(
        object sender,
        ValueChangedEventArgs e)
    {
        AtualizarParticipantes();
    }

    private void DtInicio_DateSelected(
        object sender,
        DateChangedEventArgs e)
    {
        DateTime minimo = e.NewDate.AddDays(1);

        dtTermino.MinimumDate = minimo;

        if (dtTermino.Date < minimo)
        {
            dtTermino.Date = minimo;
        }
    }

    private async void CadastrarEvento_Clicked(
        object sender,
        EventArgs e)
    {
        string nome = txtNome.Text?.Trim() ?? "";
        string local = txtLocal.Text?.Trim() ?? "";
        string custoTexto = txtCusto.Text?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(nome))
        {
            await DisplayAlert(
                "Atenção",
                "Informe o nome do evento.",
                "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(local))
        {
            await DisplayAlert(
                "Atenção",
                "Informe o local do evento.",
                "OK");
            return;
        }

        if (dtTermino.Date <= dtInicio.Date)
        {
            await DisplayAlert(
                "Atenção",
                "A data de término deve ser posterior à data de início.",
                "OK");
            return;
        }

        // Aceita valores como 50,00 ou 50.00.
        string custoNormalizado = custoTexto.Replace(',', '.');

        bool custoValido = decimal.TryParse(
            custoNormalizado,
            NumberStyles.Number,
            CultureInfo.InvariantCulture,
            out decimal custo);

        if (!custoValido || custo < 0)
        {
            await DisplayAlert(
                "Atenção",
                "Informe um custo válido por participante.",
                "OK");
            return;
        }

        Evento evento = new Evento
        {
            Nome = nome,
            DataInicio = dtInicio.Date,
            DataTermino = dtTermino.Date,
            NumeroParticipantes =
                (int)stpParticipantes.Value,
            Local = local,
            CustoPorParticipante = custo
        };

        await Navigation.PushAsync(
            new ResumoEventoPage(evento));
    }
}
