using Application.DTO.Cliente;
using Application.Util;
using Application.Validation;
using Domain.Core.Entities;
using Domain.Core.Interface;
using System.Text;

namespace Application.Business
{
    public class ClienteBusiness
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IUnitOfWork unitOfWork;

        public ClienteBusiness(IUnitOfWork unitOfWork, IClienteRepository clienteRepository)
        {
            this.unitOfWork = unitOfWork;
            this.clienteRepository = clienteRepository;
        }

        public string CriarNovoCliente(NovoClienteRequest request)
        {
            var validarDTO = new NovoClienteValidator().Validate(request);

            if (!validarDTO.IsValid)
            {
                StringBuilder sb = new StringBuilder();

                var erros = validarDTO.Errors.Select(x => x.ErrorMessage);

                foreach (string erro in erros)
                {
                    sb.AppendLine(erro);
                }

                return sb.ToString();
            }

            var cliente = new ClienteEntity()
            {
                Celular = RegexUtil.SomenteNumero(request.Ceular),
                DDD = request.DDD,
                CPF = RegexUtil.SomenteNumero(request.CPF),
                Nome = request.Nome,
                UF = request.UF,
            };

            clienteRepository.Create(cliente);
            unitOfWork.Commit();

            return "Cliente criado com sucesso";
        }
    }
}
