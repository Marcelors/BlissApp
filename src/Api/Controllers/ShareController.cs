using Application;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("share")]
    [ApiController] 
    public class ShareController : Controller
    {
        private readonly IShareService _shareService;

        public ShareController(IShareService shareService)
        {
            _shareService = shareService;
        }

        [HttpPost]
        public IActionResult Share([FromBody] ShareRequestDto dto)
        {
            _shareService.Send(dto);
            return Ok(new { status = "ok" });
        }
    }
}
