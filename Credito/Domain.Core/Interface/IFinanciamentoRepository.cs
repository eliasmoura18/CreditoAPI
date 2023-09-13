using Domain.Core.Entities;
using Domain.Core.Interface.Base;

namespace Domain.Core.Interface
{
    public interface IFinanciamentoRepository : IBaseRepository<FinanciamentoEntity>
    {
        public FinanciamentoEntity LoadReferences(FinanciamentoEntity entity);

        public List<FinanciamentoEntity> LoadReferences(List<FinanciamentoEntity> entity);
    }
}
