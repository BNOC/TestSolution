using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Api.Entities;
using Test.Api.Repositories.Contracts;

namespace Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingsController : ControllerBase
    {
        private readonly IThingRepository thingRepository;

        public ThingsController(IThingRepository thingRepository)
        {
            this.thingRepository = thingRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Thing>> GetThing(int id)
        {
            try
            {
                var thing = await this.thingRepository.GetThing(id);

                if (thing == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(thing);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving thing from database");
            }
        }

        [HttpGet]
        [Route("GetThingsForBox/{boxId}")]
        public async Task<ActionResult<IEnumerable<Thing>>> GetThingsForBox(int boxId)
        {
            try
            {
                var things = await this.thingRepository.GetThingsForBox(boxId);

                if (things == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(things);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving things for box from database");
            }
        }
    }
}
