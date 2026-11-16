
using System.Globalization;

namespace MauiAppHotel.Models
{
    public class Evento
    {
        private static readonly CultureInfo Cultura =
            CultureInfo.GetCultureInfo("pt-BR");

        public string Nome { get; set; } = string.Empty;

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public int NumeroParticipantes { get; set; }

        public string Local { get; set; } = string.Empty;

        public decimal CustoPorParticipante { get; set; }

        // TimeSpan representa a diferença entre as datas.
        public TimeSpan Duracao =>
            DataTermino.Date - DataInicio.Date;

        // Duração total em dias.
        public int DuracaoEmDias => Duracao.Days;

        // Custo total para todos os participantes.
        public decimal CustoTotal =>
            NumeroParticipantes * CustoPorParticipante;

        // Propriedades formatadas para exibição.
        public string DataInicioFormatada =>
            DataInicio.ToString("dd/MM/yyyy");

        public string DataTerminoFormatada =>
            DataTermino.ToString("dd/MM/yyyy");

        public string DuracaoFormatada =>
            DuracaoEmDias == 1
                ? "1 dia"
                : $"{DuracaoEmDias} dias";

        public string ParticipantesFormatado =>
            NumeroParticipantes == 1
                ? "1 participante"
                : $"{NumeroParticipantes} participantes";

        public string CustoPorParticipanteFormatado =>
            CustoPorParticipante.ToString("C", Cultura);

        public string CustoTotalFormatado =>
            CustoTotal.ToString("C", Cultura);
    }
}
