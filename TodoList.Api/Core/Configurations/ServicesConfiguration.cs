using Microsoft.Extensions.DependencyInjection;
using TodoList.Data;
using TodoList.Data.Repositories;
using TodoList.Domain.Interfaces;
using TodoList.Domain.Interfaces.Repositories;
using TodoList.Domain.Interfaces.Services;
using TodoList.Services;

namespace TodoList.Api.Core.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITaskService, TaskService>();

            return services;
        }
    }
}
