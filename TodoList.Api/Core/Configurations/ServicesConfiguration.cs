using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TbcIns.Services.Claims.Repository;
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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITaskService, TaskService>();

            return services;
        }
    }
}
