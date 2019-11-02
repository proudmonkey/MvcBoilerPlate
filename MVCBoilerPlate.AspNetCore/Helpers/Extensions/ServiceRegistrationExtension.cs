
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcBoilerPlate.AspNetCore.Contracts;
using System;
using System.Linq;

namespace MvcBoilerPlate.AspNetCore.Helpers.Extensions
{
    public static class ServiceRegistrationExtension
    {
        public static void AddServicesInAssembly(this IServiceCollection services, IConfiguration configuration) {
            var appServices = typeof(Startup).Assembly.ExportedTypes
                            .Where(x => typeof(IServiceRegistration)
                            .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                            .Select(Activator.CreateInstance)
                            .Cast<IServiceRegistration>().ToList();

            appServices.ForEach(svc => svc.RegisterAppServices(services, configuration));
        }
    }
}
