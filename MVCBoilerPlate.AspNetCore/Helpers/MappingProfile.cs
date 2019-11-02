using AutoMapper;
using MvcBoilerPlate.AspNetCore.Domains.Entity;
using MvcBoilerPlate.AspNetCore.Models;
using System.Collections.Generic;

namespace MvcBoilerPlate.AspNetCore.Helpers
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<Person, PersonViewModel>().ReverseMap();
        }
    }
}
