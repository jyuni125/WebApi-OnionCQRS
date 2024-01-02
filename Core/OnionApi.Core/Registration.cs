using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OnionApi.Core
{
    public static class Registration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            //services.AddMediatR(assembly);
            services.AddMediatR(c => c.RegisterServicesFromAssembly(assembly));

            return services;
        }
    }
}
    