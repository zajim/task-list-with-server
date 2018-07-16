using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TL.Abstraction.Repository;
using DM = TL.Model.Repository;

namespace TL.DbProvider.EF
{
    public class EFDbContextAdapter : IDbContextAdapter
    {
        private readonly TLDbContext _dbContext;

        public EFDbContextAdapter(TLDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<DM.Privilege> Privileges => _dbContext.Privileges;

        public IEnumerable<DM.RolePrivilege> RolePrivileges => _dbContext.RolePrivileges;

        public IEnumerable<DM.UserLogin> UserLogins => _dbContext.UserLogins;

        public IEnumerable<DM.User> Users => _dbContext.Users;

        public IEnumerable<DM.Role> Roles => _dbContext.Roles;

        public IEnumerable<DM.Task> Tasks => _dbContext.Tasks;

        public IEnumerable<DM.UserRole> UserRoles => _dbContext.UserRoles;

        public IEnumerable<DM.UserTask> UserTasks => _dbContext.UserTasks;

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Add(entity);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Remove(entity);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Update(entity);
        }
    }
}
