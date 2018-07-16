using System.Linq;
using System.Threading.Tasks;

namespace TL.Abstraction.Repository
{
    public interface ICrudRepository<T>
    {
        Task<int> AddAsync(T t);
        Task<int> RemoveAsync(T t);
        Task<int> UpdateAsync(T t);
        IQueryable<T> GetList();
    }
}
