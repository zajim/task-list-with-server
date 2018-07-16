using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DM = TL.Model.Repository;

namespace TL.Abstraction.Repository
{
    public interface IDbContextAdapter : IDisposable
    {
        IEnumerable<DM.Privilege> Privileges { get; }
        IEnumerable<DM.RolePrivilege> RolePrivileges { get; }
        IEnumerable<DM.UserLogin> UserLogins { get; }
        IEnumerable<DM.User> Users { get; }
        IEnumerable<DM.Role> Roles { get; }
        IEnumerable<DM.Task> Tasks { get; }
        IEnumerable<DM.UserRole> UserRoles { get; }
        IEnumerable<DM.UserTask> UserTasks { get; }

        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
