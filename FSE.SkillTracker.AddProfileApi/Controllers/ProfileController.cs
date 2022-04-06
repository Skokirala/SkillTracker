using FSE.SkillTracker.AddProfileApi.Application.Features.Profile.Commands;
using Microsoft.AspNetCore.Mvc;

namespace FSE.SkillTracker.AddProfileApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : BaseApiController
    {
        [HttpPost("AddProfile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddProfile([FromBody] CreateProfileCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateProfile/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(int id, UpdateProfileCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
