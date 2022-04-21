using Test.Api.Entities;

namespace Test.Api.Repositories.Contracts
{
    public interface IThingRepository
    {
        Task<Thing> GetThing(int id);

        Task<IEnumerable<Thing>> GetThingsForBox(int id);
    }
}
