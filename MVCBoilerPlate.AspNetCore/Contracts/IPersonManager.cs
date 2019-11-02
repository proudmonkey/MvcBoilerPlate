using MVCBoilerPlate.AspNetCore.Domains.Entity;

namespace MVCBoilerPlate.AspNetCore.Contracts
{
    public interface IPersonManager : IRepository<Person>
    {
        //Add class specific methods here when neccessary
    }
}
