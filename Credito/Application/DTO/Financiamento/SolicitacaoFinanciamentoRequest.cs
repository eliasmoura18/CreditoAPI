using Domain.Core.Entities.Enum;

namespace Application.DTO.Financiamento
{
    public class SolicitacaoFinanciamentoRequest
    {
        public string CPF { get; set; }
        public decimal valorCredito { get; set; }
        public TipoFinanciamentoEnum tipoCredito { get; set; }
        public int quantidadeParcelas { get; set; }
        public DateTime primeiroVencimento { get; set; }
    }
}
