using Application.BusinessRules;
using Application.DTO.Financiamento;
using Domain.Core.Entities.Enum;
using FluentValidation;

namespace Application.Validation
{
    public class SolicitacaoCreditoValidator : AbstractValidator<SolicitacaoFinanciamentoRequest>
    {
        public SolicitacaoCreditoValidator()
        {
            RuleFor(x => x.valorCredito)
                .LessThan(SolicitacaoCreditoRules.valorMaximoImprestimo).WithMessage($"Não é possível liberar crédito com valores superiores a {SolicitacaoCreditoRules.valorMaximoImprestimo.ToString("C")}.");

            RuleFor(x => x.quantidadeParcelas)
                .GreaterThan(SolicitacaoCreditoRules.qtdeMinParcelas).WithMessage($"O número de parcelas deve ser {SolicitacaoCreditoRules.qtdeMinParcelas} ou superior.")
                .LessThan(SolicitacaoCreditoRules.qtdeMaxParcelas).WithMessage($"O número de parcelas não pode ser suprior a {SolicitacaoCreditoRules.qtdeMaxParcelas}.");

            RuleFor(x => new { x.tipoCredito, x.valorCredito })
                .Must(x => ValorMinimoCreditoPJ(x.tipoCredito, x.valorCredito)).WithMessage($"Para Pessoa Jurídica, o valor mínimo para liberação de crédito é de {SolicitacaoCreditoRules.valorMinimoImprestimoPessoaJuridica.ToString("C")}");

            RuleFor(x => x.primeiroVencimento)
                .GreaterThan(DateTime.Now.AddDays(SolicitacaoCreditoRules.prazoMinimoVencimentoPrimeiraParcela)).WithMessage($"A data mínima da primeira parcela é de {SolicitacaoCreditoRules.prazoMinimoVencimentoPrimeiraParcela} dias")
                .LessThan(DateTime.Now.AddDays(SolicitacaoCreditoRules.prazoMaximoVencimentoPrimeiraParcela)).WithMessage($"A data máxima da primeira parcela é de {SolicitacaoCreditoRules.prazoMaximoVencimentoPrimeiraParcela} dias");
        }

        private bool ValorMinimoCreditoPJ(TipoFinanciamentoEnum tipoFinanciamento, decimal valorCredito)
        {
            bool retorno = tipoFinanciamento == TipoFinanciamentoEnum.CreditoPessoaJuridica && valorCredito < SolicitacaoCreditoRules.valorMinimoImprestimoPessoaJuridica;
            return !retorno;
        }
    }
}
