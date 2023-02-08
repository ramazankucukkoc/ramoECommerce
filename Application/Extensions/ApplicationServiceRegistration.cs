using Application.Features.Addresss.Rules;
using Application.Features.Auths.Rules;
using Application.Features.Baskets.Rules;
using Application.Features.Brands.Rules;
using Application.Features.Categories.Rules;
using Application.Features.Cities.Rules;
using Application.Features.Countries.Rules;
using Application.Features.Departmans.Rules;
using Application.Features.OperationClaims.Rules;
using Application.Features.Orders.Rules;
using Application.Features.Personels.Rules;
using Application.Features.Products.Rules;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.BrandService;
using Application.Services.ProductService;
using Application.Services.UserService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Mailings;
using Core.Mailings.MailKitImplementations;
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
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<ProductBusinnessRules>();
            services.AddScoped<OrderBusinessRules>();
            services.AddScoped<BrandBusinessRules>();
            services.AddScoped<AddressBusinessRules>();
            services.AddScoped<BasketBusinessRules>();
            services.AddScoped<CitiesBusinessRules>();
            services.AddScoped<CountryBusinessRules>();
            services.AddScoped<DepartmanBusinessRules>();
            services.AddScoped<PersonelBusinessRules>();
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
            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IProductService, ProductManager>();
           
            //-----------------Business Services----------------------
            services.AddSingleton<IMailService, MailKitMailService>();

            return services;
        }
    }
}
