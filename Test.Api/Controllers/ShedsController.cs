using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Api.Entities;
using Test.Api.Repositories.Contracts;

namespace Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShedsController : ControllerBase
    {
        private readonly IShedRepository shedRepository;

        public ShedsController(IShedRepository shedRepository)
        {
            this.shedRepository = shedRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Shed>> GetShed(int id)
        {
            try
            {
                var shed = await this.shedRepository.GetShed(id);

                if (shed == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(shed);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving shed from database");
            }
        }
    }
}
