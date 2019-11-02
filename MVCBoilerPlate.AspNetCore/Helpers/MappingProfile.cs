using AutoMapper;
using MVCBoilerPlate.AspNetCore.Domains.Entity;
using MVCBoilerPlate.AspNetCore.Models;
using System.Collections.Generic;

namespace MVCBoilerPlate.AspNetCore.Helpers
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<Person, PersonViewModel>().ReverseMap();
        }
    }
}
