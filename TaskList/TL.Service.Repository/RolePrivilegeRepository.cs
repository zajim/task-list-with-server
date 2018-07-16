using System.Linq;
using System.Threading.Tasks;
using TL.Abstraction.Repository;
using TL.Model.Repository;

namespace TL.Service.Repository
{
    public class RolePrivilegeRepository : ICrudRepository<RolePrivilege>
    {
        private readonly IDbContextAdapter _dbContext;

        public RolePrivilegeRepository(IDbContextAdapter dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> AddAsync(RolePrivilege t)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<RolePrivilege> GetList()
        {
            return _dbContext.RolePrivileges.AsQueryable();
        }

        public Task<int> RemoveAsync(RolePrivilege t)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateAsync(RolePrivilege t)
        {
            throw new System.NotImplementedException();
        }
    }
}
