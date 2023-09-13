using Application.Business;
using Application.DTO.Cliente;
using Domain.Core.Entities;
using Domain.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IUnitOfWork unitOfWork;

        public ClienteController(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            this.clienteRepository = clienteRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteEntity>>> BuscarClientesUF()
        {
            try
            {
                List<ClienteEntity> clientes = clienteRepository.GetAll();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteEntity>> BuscarPorId(int id)
        {
            try
            {
                ClienteEntity clientes = clienteRepository.Get(id);
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClienteEntity>> NovoCliente([FromBody] NovoClienteRequest cliente)
        {
            try
            {
                ClienteBusiness clienteBusiness = new ClienteBusiness(unitOfWork, clienteRepository);
                string retorno = clienteBusiness.CriarNovoCliente(cliente);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
