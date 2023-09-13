using Domain.Core.Entities;
using Domain.Core.Interface;
using Infraestructure.Context;
using Infraestructure.Repositories.Base;

namespace Infraestructure.Repositories
{
    public class ParcelaRepository : BaseRepository<ParcelaEntity>, IParcelaRepository
    {
        public ParcelaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
