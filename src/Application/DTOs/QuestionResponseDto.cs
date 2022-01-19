using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Application.DTOs
{
    public class QuestionResponseDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbUrl { get; set; }
        public string Question { get; set; }
        public DateTime PublishedAt { get; set; }
        public List<ChoiceResponseDto> Choices { get; set; } = new();

        public static implicit operator QuestionResponseDto(Questions entity) =>
            new()
            {
                Id = entity.Id,
                ImageUrl = entity.ImageUrl,
                ThumbUrl = entity.ThumbUrl,
                Question = entity.Question,
                PublishedAt = entity.PublishedAt,
                Choices = entity.Choices.Select(choice => new ChoiceResponseDto
                {
                    Votes = choice.Votes,
                    Choice = choice.Choice
                }).ToList()
            };
    }
}
