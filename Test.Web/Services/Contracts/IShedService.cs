using Test.Web.Models;

namespace Test.Web.Services.Contracts
{
    public interface IShedService
    {
        Task<ShedBase> GetShed(int id);
    }
}
