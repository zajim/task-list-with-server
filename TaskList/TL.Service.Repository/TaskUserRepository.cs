using System.Linq;
using System.Threading.Tasks;
using TL.Abstraction.Repository;
using TL.Model.Repository;

namespace TL.Service.Repository
{
    public class TaskUserRepository : ICrudRepository<UserTask>
    {
        private readonly IDbContextAdapter _dbContext;

        public TaskUserRepository(IDbContextAdapter dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(UserTask userTask)
        {
            _dbContext.Add(userTask);
            return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public IQueryable<UserTask> GetList()
        {
            return _dbContext.UserTasks.AsQueryable();
        }

        public Task<int> RemoveAsync(UserTask userTask)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateAsync(UserTask userTask)
        {
            throw new System.NotImplementedException();
        }
    }
}
