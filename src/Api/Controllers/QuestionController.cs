using System.Threading.Tasks;
using Application;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("questions")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilterDto filterDto)
        {
           var result = await _questionService.Get(filterDto);
           return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _questionService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] QuestionCreatedRequestDto request)
        {
            var result = await _questionService.Add(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] QuestionUpdatedRequestDto request)
        {
            var result = await _questionService.Update(id, request);
            return Ok(result);
        }
    }
}
