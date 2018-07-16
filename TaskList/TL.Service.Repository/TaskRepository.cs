using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TL.Abstraction.Repository;
using DM = TL.Model.Repository;

namespace TL.Service.Repository
{
    public class TaskRepository : ICrudRepository<DM.Task>
    {
        private readonly IDbContextAdapter _dbContext;

        public TaskRepository(IDbContextAdapter dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(DM.Task task)
        {
            _dbContext.Add(task);
            return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public IQueryable<DM.Task> GetList()
        {
            return _dbContext.Tasks.AsQueryable();
        }

        public async Task<int> RemoveAsync(DM.Task task)
        {
            _dbContext.Remove(task);
            return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> UpdateAsync(DM.Task task)
        {
            _dbContext.Update(task);
            return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
