using Application.Features.Auths.Rules;
using Application.Features.OperationClaims.Rules;
using Application.Services.AuthService;
using Application.Services.UserService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;

using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions
{
    public static class ApplicationServiceRegistration
    {
        //Services buraya ekleniyor.Repository(repolar)persistence Katmanına ekleniyor. !!!!!
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //-----------------Business Rules----------------------
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<OperationClaimsBusinessRules>();

            //-----------------Business Rules----------------------

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionScopeBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));

            // services.AddScoped<LoggerServiceBase, PostgreSqlLogger>();
            //services.AddTransient<IMessageBrokerHelper, MqQueueHelper>();

            //-----------------Business Services----------------------

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IUserService, UserManager>();


            //-----------------Business Services----------------------

            return services;
        }
    }
}
