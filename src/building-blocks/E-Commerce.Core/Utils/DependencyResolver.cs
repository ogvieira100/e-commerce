using DeveloperEvaluation.MessageBus.Models;
using E_Commerce.Core.Data;
using E_Commerce.Core.Validation;
using E_Commerce.MessageBus.Interface;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Utils
{
    public static class DependencyResolver
    {

        public static void RegisterDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped(typeof(IRepositoryConsult<>), typeof(RepositoryConsult<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddSingleton<IMessageBusRabbitMq, MessageBusRabbitMq>();
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
