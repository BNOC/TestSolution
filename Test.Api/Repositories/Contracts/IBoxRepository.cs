using Test.Api.Entities;

namespace Test.Api.Repositories.Contracts
{
    public interface IBoxRepository
    {

        Task<Box> GetBox(int id);

        Task<IEnumerable<Box>> GetBoxesForShed(int id);
    }
}
