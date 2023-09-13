namespace Application.DTO.Financiamento
{
    public class SolicitacaoFinanciamentoResponse
    {
        public string StatusCredito { get; set; }
        public decimal ValorTotalComJuros { get; set; }
        public decimal ValorJuros { get; set; }
        public string Observacao { get; set; }
    }
}
