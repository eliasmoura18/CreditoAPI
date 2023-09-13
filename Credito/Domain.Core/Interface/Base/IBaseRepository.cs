using Domain.Core.Entities.Base;

namespace Domain.Core.Interface.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Get(int id);
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
