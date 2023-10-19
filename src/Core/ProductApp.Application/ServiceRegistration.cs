using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProductApp.Application
{
    public static class ServiceRegistration 
    {
        public static void AddApplicationServices(this IServiceCollection serviceDescriptors)
        {
            var assembly = Assembly.GetExecutingAssembly();
            serviceDescriptors.AddAutoMapper(assembly);
            serviceDescriptors.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

        }
    }
}
