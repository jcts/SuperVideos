using Microsoft.AspNetCore.Mvc;
using System;

namespace SuperVideos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueApiController : ControllerBase
    {
        /// <summary>
        /// Insere um filme na fila de integração
        /// </summary>
        /// <returns></returns>
        [HttpPost("InsertQueu")]
        public IActionResult InsertQueue()
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
