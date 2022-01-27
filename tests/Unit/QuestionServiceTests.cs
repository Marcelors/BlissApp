using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.DTOs;
using Application.Shared;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Globalization;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Unit
{
    public class QuestionServiceTests
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionService _questionService;

        public QuestionServiceTests()
        {
            _questionRepository = Substitute.For<IQuestionRepository>();
            _questionService = new QuestionService(_questionRepository);
        }

        [Fact]
        public async Task Add_should_add_a_question_and_returns_question_response_dto()
        {
            var request = new QuestionCreatedRequestDto
            {
                Choices = new List<string>() { "Apple", "Amazon" },
                ImageUrl = "http://image.com",
                Question = "question test",
                ThumbUrl = "http://thumb.com"
            };

            var expected = new QuestionResponseDto
            {
                Choices = new List<ChoiceResponseDto>
                {
                    new() {Choice = "Apple", Votes = 0},
                    new() {Choice = "Amazon", Votes = 0},
                },
                ImageUrl = "http://image.com",
                Question = "question test",
                ThumbUrl = "http://thumb.com"
            };

            var result = await _questionService.Add(request);

            result.Should().BeEquivalentTo(expected, config => config.Excluding(y => y.PublishedAt));
        }


        [Fact]
        public async Task GetById_should_returns_a_question_response_dto()
        {
            const int id = 1;

            var question = new Questions("question test", "http://image.com", "http://thumb.com");

            var choices = new[] { "Apple", "Microsoft", "Amazon" };

            question.AddChoices(choices.ToList());

            var expected = new QuestionResponseDto
            {
                Choices = new List<ChoiceResponseDto>
                {
                    new() {Choice = "Apple", Votes = 0},
                    new() {Choice = "Microsoft", Votes = 0},
                    new() {Choice = "Amazon", Votes = 0},
                },
                ImageUrl = "http://image.com",
                Question = "question test",
                ThumbUrl = "http://thumb.com"
            };

            _questionRepository.GetById(id).Returns(question);

            var result = await _questionService.GetById(id);

            result.Should().BeEquivalentTo(expected, config => config.Excluding(y => y.PublishedAt));
        }

        [Fact]
        public async Task GetById_throw_not_found_expection()
        {
            const int id = 1;

            _questionRepository.GetById(id).ReturnsNull();

            Func<Task> action = () => _questionService.GetById(id);

            await action.Should().ThrowAsync<NotFoundException>().WithMessage(Resource.QuestionNotFound);
        }

        [Fact]
        public async Task Get_should_returns_a_paginated_question_response_dto()
        {
            const int amount = 10;

            var questions = CreateQuestions(amount);

            (int totalItems, List<Questions> questions) queryResult = (amount, questions);

            _questionRepository.Get(null, null, null).Returns(queryResult);

            var expected = new PaginatedQuestionResponseDto
            {
                Questions = CreateQuestionsReponse(amount),
                TotalItems = amount
            };

            var result = await _questionService.Get(new FilterDto());

            result.TotalItems.Should().Be(expected.TotalItems);
            result.Questions.Should().BeEquivalentTo(expected.Questions, config => config.Excluding(y => y.PublishedAt));
        }

        private List<Questions> CreateQuestions(int amount)
        {
            var questions = new List<Questions>();

            for (int i = 0; i < amount; i++)
            {
                var question = new Questions($"question test {i}", "http://image.com", "http://thumb.com");
                var choices = new[] { "Apple", "Microsoft", "Amazon" };

                question.AddChoices(choices.ToList());
                questions.Add(question);
            }

            return questions;
        }

        private List<QuestionResponseDto> CreateQuestionsReponse(int amount)
        {
            var questions = new List<QuestionResponseDto>();

            for (int i = 0; i < amount; i++)
            {
                var question = new QuestionResponseDto
                {
                    Choices = new List<ChoiceResponseDto>
                    {
                        new() {Choice = "Apple", Votes = 0},
                        new() {Choice = "Microsoft", Votes = 0},
                        new() {Choice = "Amazon", Votes = 0},
                    },
                    ImageUrl = "http://image.com",
                    Question = $"question test {i}",
                    ThumbUrl = "http://thumb.com"
                };

                questions.Add(question);

            }

            return questions;
        }

        [Fact]
        public async Task Update_throw_not_found_expection()
        {
            const int id = 1;

            var request = new QuestionUpdatedRequestDto
            {
                Choices = new List<ChoiceRequestDto>
                {
                    new() {Choice = "Apple", Votes = 10},
                    new() {Choice = "Amazon", Votes = 15},
                },
                ImageUrl = "http://image.com",
                Question = "question test1",
                ThumbUrl = "http://thumb.com"
            };

            _questionRepository.GetById(id).ReturnsNull();

            Func<Task> action = () => _questionService.Update(id, request);

            await action.Should().ThrowAsync<NotFoundException>().WithMessage(Resource.QuestionNotFound);
        }

        [Fact]
        public async Task Update_throw_business_exception()
        {
            const int id = 1;

            var question = new Questions("question test", "http://image.com", "http://thumb.com");
            var choices = new[] { "Apple", "Microsoft", "Amazon" };
            question.AddChoices(choices.ToList());

            var request = new QuestionUpdatedRequestDto
            {
                Choices = new List<ChoiceRequestDto>
                {
                    new() {Choice = "Apple", Votes = 10},
                    new() {Choice = "Amazon", Votes = 15},
                },
                ImageUrl = "http://image.com",
                Question = "question test1",
                ThumbUrl = "http://thumb.com"
            };

            _questionRepository.GetById(id).Returns(question);

            Func<Task> action = () => _questionService.Update(id, request);

            await action.Should().ThrowAsync<BusinessException>().WithMessage(Resource.QuestionShouldNotIsChanged);
        }

        [Fact]
        public async Task Update_should_add_votes_in_choices()
        {
            const int id = 1;

            var question = new Questions("question test", "http://image.com", "http://thumb.com");
            var choices = new[] { "Apple", "Microsoft", "Amazon" };
            question.AddChoices(choices.ToList());

            var request = new QuestionUpdatedRequestDto
            {
                Choices = new List<ChoiceRequestDto>
                {
                    new() {Choice = "Microsoft", Votes = 10},
                    new() {Choice = "Apple", Votes = 10},
                    new() {Choice = "Amazon", Votes = 15},
                },
                ImageUrl = "http://image.com",
                Question = "question test",
                ThumbUrl = "http://thumb.com"
            };

            _questionRepository.GetById(id).Returns(question);

            var expected = new QuestionResponseDto
            {
                Choices = new List<ChoiceResponseDto>
                {
                    new() {Choice = "Apple", Votes = 10},
                    new() {Choice = "Microsoft", Votes = 10},
                    new() {Choice = "Amazon", Votes = 15},
                },
                ImageUrl = "http://image.com",
                Question = "question test",
                ThumbUrl = "http://thumb.com"
            };

            var result = await _questionService.Update(id, request);

            result.Should().BeEquivalentTo(expected, config => config.Excluding(y => y.PublishedAt));
        }
    }
}
