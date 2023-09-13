using Domain.Core.Entities.Enum;

namespace Application.Util
{
    public static class JurosUtil
    {
        public static decimal CalcularJuros(decimal valorCredito, TipoFinanciamentoEnum tipoFinanciamento)
        {
            decimal retorno = 0;

            switch (tipoFinanciamento)
            {
                case TipoFinanciamentoEnum.CreditoDireto:
                    retorno = valorCredito * 1.02m;
                    break;

                case TipoFinanciamentoEnum.CreditoConsignado:
                    retorno = valorCredito * 1.01m;
                    break;
                    
                case TipoFinanciamentoEnum.CreditoPessoaJuridica:
                    retorno = valorCredito * 1.05m;
                    break;
                    
                case TipoFinanciamentoEnum.CreditoPessoaFisica:
                    retorno = valorCredito * 1.03m;
                    break;
                    
                case TipoFinanciamentoEnum.CreditoImobiliario:
                    retorno = valorCredito * 1.09m;
                    break;
                default:
                    throw new Exception("Não foi possível calcular o Juros do financiamento. Tipo de financiamento não esperado");

            }

            return retorno;
        }
    }
}
