using FluentValidation;
using System;

namespace MvcBoilerPlate.AspNetCore.Models
{
    public class PersonViewModel
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class PersonViewModelValidator : AbstractValidator<PersonViewModel>
    {
        public PersonViewModelValidator() {
            RuleFor(o => o.FirstName).NotEmpty();
            RuleFor(o => o.LastName).NotEmpty();
            RuleFor(o => o.DateOfBirth).NotEmpty();
        }
    }
}
