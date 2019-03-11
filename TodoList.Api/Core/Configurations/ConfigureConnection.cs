using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Data.Database;

namespace TodoList.Api.Core.Configurations
{
    public static class ConfigureConnection
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TodoListConnection");
            services.AddDbContext<TodoListContext>(options => options.UseSqlServer(connectionString, b=>b.MigrationsAssembly("TodoList.Api")));

            return services;
        }
    }
}
