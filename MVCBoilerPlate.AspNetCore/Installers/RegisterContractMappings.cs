using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcBoilerPlate.AspNetCore.Contracts;
using MvcBoilerPlate.AspNetCore.Domains.DataManager;

namespace MvcBoilerPlate.AspNetCore.Installers
{
    public class RegisterContractMappings: IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration) {
            //Register Interface Mappings for Repositories
            services.AddTransient<IPersonManager, PersonManager>();
        }
    }
}
