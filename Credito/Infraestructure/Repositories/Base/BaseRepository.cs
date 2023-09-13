using Domain.Core.Entities.Base;
using Domain.Core.Interface.Base;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext context;
        protected readonly DbSet<T> dataSet;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
            dataSet = this.context.Set<T>();
        }

        public T Get(int id)
        {
            return dataSet.FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return dataSet.ToList();
        }

        public void Create(T entity)
        {
            entity.DataInsercao = DateTime.Now;
            context.Add(entity);
        }

        public void Update(T entity)
        {
            entity.DataAlteracao = DateTime.Now;
            context.Update(entity);
        }

        public void Delete(T entity)
        {
            entity.DataExclusao = DateTime.Now;
            context.Update(entity);
        }
    }
}
