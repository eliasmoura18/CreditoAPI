using Application.DTO.Financiamento;
using Application.Util;
using Application.Validation;
using Domain.Core.Entities;
using Domain.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Business
{
    public class FinanciamentoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFinanciamentoRepository financiamentoRepository;
        private readonly IClienteRepository clienteRepository;
        private readonly IParcelaRepository parcelaRepository;

        public FinanciamentoBusiness(IUnitOfWork unitOfWork, IFinanciamentoRepository financiamento, IClienteRepository cliente, IParcelaRepository parcela)
        {
            this.unitOfWork = unitOfWork;
            financiamentoRepository = financiamento;
            clienteRepository = cliente;
            parcelaRepository = parcela;
        }

        public SolicitacaoFinanciamentoResponse NovaSolicitacaoFinanciamento(SolicitacaoFinanciamentoRequest solicitacaoDTO)
        {
            var retorno = new SolicitacaoFinanciamentoResponse();

            var validarDTO = new SolicitacaoCreditoValidator().Validate(solicitacaoDTO);

            if (!validarDTO.IsValid)
            {
                StringBuilder sb = new StringBuilder();

                var erros = validarDTO.Errors.Select(x => x.ErrorMessage);

                foreach (string erro in erros)
                {
                    sb.AppendLine(erro);
                }

                retorno.Observacao = sb.ToString();
                retorno.StatusCredito = "Recusado";
                return retorno;
            }

            if (!CPFUtil.isValidoCPFVazio(solicitacaoDTO.CPF))
            {
                retorno.Observacao = "O CPF é um campo obrigatório";
                retorno.StatusCredito = "Recusado";
                return retorno;
            }

            solicitacaoDTO.CPF = RegexUtil.SomenteNumero(solicitacaoDTO.CPF);

            var cliente = clienteRepository.GetByCPF(solicitacaoDTO.CPF);

            if (cliente == null)
            {
                retorno.Observacao = "CPF não encontrado";
                retorno.StatusCredito = "Recusado";
                return retorno;
            }

            var valorTotal = JurosUtil.CalcularJuros(solicitacaoDTO.valorCredito, solicitacaoDTO.tipoCredito);

            FinanciamentoEntity financiamentoEntity = new FinanciamentoEntity()
            {
                Cliente = cliente,
                CPF = cliente.CPF,
                DataUltimoVencimento = solicitacaoDTO.primeiroVencimento.AddMonths(solicitacaoDTO.quantidadeParcelas - 1),
                TipoFinanciamento = solicitacaoDTO.tipoCredito,
                ValorTotal = valorTotal,
            };

            List<ParcelaEntity> parcelas = new List<ParcelaEntity>();

            for (int i = 0; i < solicitacaoDTO.quantidadeParcelas; i ++)
            {
                parcelas.Add(new ParcelaEntity()
                {
                    Financiamento = financiamentoEntity,
                    DataVencimento = solicitacaoDTO.primeiroVencimento.AddMonths(i),
                    NumeroParcela = i + 1,
                    ValorParcela = valorTotal / solicitacaoDTO.quantidadeParcelas,
                });
            }

            financiamentoRepository.Create(financiamentoEntity);

            foreach (var parc in parcelas)
            {
                parcelaRepository.Create(parc);
            }

            unitOfWork.Commit();

            retorno.Observacao = "Solicitação concluída com sucesso";
            retorno.StatusCredito = "Aprovado";
            retorno.ValorJuros = valorTotal - solicitacaoDTO.valorCredito;
            retorno.ValorTotalComJuros = valorTotal;

            return retorno;
        }

    }
}
