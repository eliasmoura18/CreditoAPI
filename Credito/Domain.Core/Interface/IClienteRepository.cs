using Domain.Core.Entities;
using Domain.Core.Interface.Base;

namespace Domain.Core.Interface
{
    public interface IClienteRepository : IBaseRepository<ClienteEntity>
    {
        public ClienteEntity LoadReferences(ClienteEntity entity);
        public ClienteEntity GetByCPF(string cpf);
    }
}
