using MvcBoilerPlate.AspNetCore.Domains.Entity;

namespace MvcBoilerPlate.AspNetCore.Contracts
{
    public interface IPersonManager : IRepository<Person>
    {
        //Add class specific methods here when neccessary
    }
}
