using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Infrastructure.Data;
using ToDo.Infrastructure.Repository;

namespace ToDo.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection ConfigureInfrastructureModule(this IServiceCollection services, string connectionString)
        {
            return services
                .AddSingleton(new PostgreSQLAdapter(connectionString))
                .AddRepositories();
        }

        internal static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IToDoRepository, ToDoRepository>();
        }
    }
}
