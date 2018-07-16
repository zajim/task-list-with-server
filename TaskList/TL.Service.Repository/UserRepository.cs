using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TL.Abstraction.Repository;
using TL.Model.Repository;

namespace TL.Service.Repository
{
    public class UserRepository : ICrudRepository<User>
    {
        private readonly IDbContextAdapter _dbContext;

        public UserRepository(IDbContextAdapter dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> AddAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<User> GetList()
        {
            return _dbContext.Users.AsQueryable();
        }

        public Task<int> RemoveAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
