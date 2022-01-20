﻿using System.Threading.Tasks;
using Application;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("questions")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _questionService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(QuestionCreatedRequestDto request)
        {
            var result = await _questionService.Add(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, QuestionUpdatedRequestDto request)
        {
            var result = await _questionService.Update(id, request);
            return Ok(result);
        }
    }
}