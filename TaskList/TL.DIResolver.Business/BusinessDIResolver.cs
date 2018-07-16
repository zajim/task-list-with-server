using Microsoft.Extensions.DependencyInjection;
using TL.Abstraction.Business;
using TL.Service.Business;

namespace TL.DIResolver.Business
{
    public class BusinessDIResolver
    {
        public static void ConfigureServices(IServiceCollection container)
        {
            container.AddScoped<IUserBusiness, UserBusiness>();
            container.AddScoped<ITaskBusiness, TaskBusiness>();
        }
    }
}
