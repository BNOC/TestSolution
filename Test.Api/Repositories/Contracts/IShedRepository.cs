using Test.Api.Entities;

namespace Test.Api.Repositories.Contracts
{
    public interface IShedRepository
    {
        Task<Shed> GetShed(int id);
    }
}
