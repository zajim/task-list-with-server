using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TL.Abstraction.Repository;
using TL.DbProvider.EF;
using TL.Model.Repository;
using TL.Service.Repository;

namespace TL.DIResolver.Repository
{
    public class RepositoryDIResolver
    {
        public static void ConfigureServices(IServiceCollection container, IConfiguration configuration)
        {
            container.AddDbContext<TLDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            container.AddScoped<ICrudRepository<Task>, TaskRepository>();
            container.AddScoped<ICrudRepository<UserTask>, TaskUserRepository>();
            container.AddScoped<ICrudRepository<UserLogin>, UserLoginRepository>();
            container.AddScoped<ICrudRepository<RolePrivilege>, RolePrivilegeRepository>();
            container.AddScoped<ICrudRepository<User>, UserRepository>();
            container.AddScoped<IDbContextAdapter, EFDbContextAdapter>();
        }
    }
}
