using Domain.Core.Entities;
using Domain.Core.Interface;
using Infraestructure.Context;
using Infraestructure.Repositories.Base;

namespace Infraestructure.Repositories
{
    public class FinanciamentoRepository : BaseRepository<FinanciamentoEntity>, IFinanciamentoRepository
    {
        public FinanciamentoRepository(AppDbContext context) : base(context)
        {
        }

        public FinanciamentoEntity LoadReferences(FinanciamentoEntity entity)
        {
            if (entity == null)
                return null;

            context.Entry(entity).Reference(x => x.Cliente).Load();

            return entity;
        }

        public List<FinanciamentoEntity> LoadReferences(List<FinanciamentoEntity> entity)
        {
            if (entity == null || !entity.Any())
                return null;

            var financiamentos = new List<FinanciamentoEntity>();

            foreach (var ent in entity)
            {
                financiamentos.Add(LoadReferences(ent));
            }

            return financiamentos;
        }
    }
}
