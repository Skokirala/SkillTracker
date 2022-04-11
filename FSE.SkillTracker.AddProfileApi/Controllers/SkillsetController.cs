using FSE.SkillTracker.AddProfileApi.Application.Features.Skillset.Commands;
using Microsoft.AspNetCore.Mvc;

namespace FSE.SkillTracker.AddProfileApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsetController : BaseApiController
    {
        [HttpPost("AddSkillset")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddSkillset([FromBody] CreateSkillsetCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
