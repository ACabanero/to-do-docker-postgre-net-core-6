using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Services;
using ToDo.Domain.Interfaces.Services;
using ToDo.Infrastructure;

namespace ToDo.Core
{
    public static class CoreModule
    {
        public static IServiceCollection ConfigureCoreModule(this IServiceCollection services, string connectionString)
        {
            return services
                .ConfigureInfrastructureModule(connectionString)
                .AddServices();
        }

        internal static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IToDoService, ToDoService>();
        }
    }
}
