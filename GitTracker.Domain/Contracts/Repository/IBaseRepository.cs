using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitTracker.Domain.Contracts.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void AddAll(IList<T> entities);

        T Update(T entity);
        void UpdateAll(IList<T> entities);

        void Remove(T entity);
        Task RemoveAll();

        void SaveChanges();
        Task SaveChangesAsync();
    }
}