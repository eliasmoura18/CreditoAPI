using Application.Business;
using Application.DTO.Financiamento;
using Domain.Core.Entities;
using Domain.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanciamentoController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IFinanciamentoRepository _financiamentoRepository;
        private readonly IParcelaRepository _parcelaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FinanciamentoController(IUnitOfWork unitOfWork, IClienteRepository cliente, IFinanciamentoRepository financiamento, IParcelaRepository parcela)
        {
            _unitOfWork = unitOfWork;
            _clienteRepository = cliente;
            _financiamentoRepository = financiamento;
            _parcelaRepository = parcela;
        }

        [HttpGet]
        public ActionResult<List<FinanciamentoEntity>> BuscarFinanciamentos()
        {
            try
            {
                var financiamentos = _financiamentoRepository.GetAll();
                financiamentos = _financiamentoRepository.LoadReferences(financiamentos);
                return Ok(financiamentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<SolicitacaoFinanciamentoResponse> SolicitarFinanciamento([FromBody]SolicitacaoFinanciamentoRequest requestSolicitacaoDTO)
        {
            try
            {
                var solicitarCreditoBusiness = new FinanciamentoBusiness(_unitOfWork, _financiamentoRepository, _clienteRepository, _parcelaRepository);
                var response = solicitarCreditoBusiness.NovaSolicitacaoFinanciamento(requestSolicitacaoDTO);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
