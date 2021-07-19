using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProJur.Domain.Application.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);

        Task Create(T item);

        Task Update(T item);

        Task Delete(T item);
    }
}