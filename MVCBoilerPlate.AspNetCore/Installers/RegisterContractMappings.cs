using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCBoilerPlate.AspNetCore.Contracts;
using MVCBoilerPlate.AspNetCore.Domains.DataManager;

namespace MVCBoilerPlate.AspNetCore.Installers
{
    public class RegisterContractMappings: IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration) {
            //Register Interface Mappings for Repositories
            services.AddTransient<IPersonManager, PersonManager>();
        }
    }
}
