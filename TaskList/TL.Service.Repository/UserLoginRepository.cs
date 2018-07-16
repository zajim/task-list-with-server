using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL.Abstraction.Repository;
using TL.Model.Repository;

namespace TL.Service.Repository
{
    public class UserLoginRepository : ICrudRepository<UserLogin>
    {
        private readonly IDbContextAdapter _dbContext;

        public UserLoginRepository(IDbContextAdapter dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(UserLogin userLogin)
        {
            _dbContext.Add(userLogin);
            return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public IQueryable<UserLogin> GetList()
        {
            return _dbContext.UserLogins.AsQueryable();
        }

        public Task<int> RemoveAsync(UserLogin userLogin)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(UserLogin userLogin)
        {
            _dbContext.Update(userLogin);
            return await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
