using Microsoft.Extensions.DependencyInjection;

namespace Core.Application.Extensions
{
    public static class CorsPolicyExtensions
    {
        public static IServiceCollection ConfigureCorsPolicy(this IServiceCollection services)
        {
            //services.addcors(opt =>
            //{
            //    opt.AddDefaultPolicy(builder => builder
            //        .AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader());
            //});
            return services;
        }
    }
}
