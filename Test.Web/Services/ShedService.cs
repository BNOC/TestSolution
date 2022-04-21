using System.Net.Http.Json;
using Test.Web.Models;
using Test.Web.Services.Contracts;

namespace Test.Web.Services
{
    public class ShedService : IShedService
    {
        private readonly HttpClient client;

        public ShedService(HttpClient _client)
        {
            client = _client;
        }

        public async Task<ShedBase> GetShed(int id)
        {
            try
            {
                var response = await client.GetAsync($"api/Sheds/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default;
                    }

                    return await response.Content.ReadFromJsonAsync<ShedBase>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
