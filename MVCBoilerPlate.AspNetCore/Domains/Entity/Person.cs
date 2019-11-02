using System;

namespace MvcBoilerPlate.AspNetCore.Domains.Entity
{
    public class Person : EntityBase
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
