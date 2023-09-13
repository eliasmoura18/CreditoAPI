using Application.Util;
using Domain.Core.Entities;
using Domain.Core.Interface;
using Infraestructure.Context;
using Infraestructure.Repositories.Base;
using System.Text.RegularExpressions;

namespace Infraestructure.Repositories
{
    public class ClienteRepository : BaseRepository<ClienteEntity>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }

        public ClienteEntity GetByCPF(string cpf)
        {
            if (!CPFUtil.isValidoCPFVazio(cpf))
                return null;

            return context.Clientes.Where(x => x.CPF == cpf).FirstOrDefault();
        }

        public ClienteEntity LoadReferences(ClienteEntity entity)
        {
            if (entity == null)
                return null;

            return entity;
        }
    }
}
