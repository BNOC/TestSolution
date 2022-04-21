using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Api.Entities;
using Test.Api.Repositories.Contracts;

namespace Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxesController : ControllerBase
    {
        private readonly IBoxRepository boxRepository;

        public BoxesController(IBoxRepository boxRepository)
        {
            this.boxRepository = boxRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Box>> GetBox(int id)
        {
            try
            {
                var box = await this.boxRepository.GetBox(id);

                if (box == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(box);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving box from database");
            }
        }

        [HttpGet]
        [Route("GetBoxesForShed/{shedId}")]
        public async Task<ActionResult<IEnumerable<Box>>> GetBoxesForShed(int shedId)
        {
            try
            {
                var boxes = await this.boxRepository.GetBoxesForShed(shedId);

                if (boxes == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(boxes);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving boxes for shed from database");
            }
        }
    }
}
