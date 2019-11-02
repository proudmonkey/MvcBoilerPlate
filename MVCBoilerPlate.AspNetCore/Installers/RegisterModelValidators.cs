using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcBoilerPlate.AspNetCore.Contracts;
using MvcBoilerPlate.AspNetCore.Models;

namespace MVCBoilerPlate.AspNetCore.Installers
{
    public class RegisterModelValidators: IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration) {
            //Register DTO Validators
            services.AddTransient<IValidator<PersonViewModel>, PersonViewModelValidator>();
        }
    }
}
