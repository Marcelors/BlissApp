using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Api;
using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Integration
{
    [Collection("API-TESTS")]
    public class QuestionApiTests : IntegrationTestFixture
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionApiTests(TestingWebApplicationFactory<Startup> factory) : base(factory)
        {
            _questionRepository = ServiceProviderHelper.ServiceProvider.GetRequiredService<IQuestionRepository>();
        }

        [Fact]
        public async Task Post_to_questions_returns_200_when_passing_valid_data()
        {
            var request = new QuestionCreatedRequestDto
            {
                Choices = new List<string>() { "Apple", "Amazon" },
                ImageUrl = "http://image.com",
                Question = "question test",
                ThumbUrl = "http://thumb.com"
            };

            var response = await HttpClient.PostAsync("questions", request.ToJsonContent());
            var body = await response.Content.ReadAsAsync<QuestionResponseDto>();

            var expectedChoices = new List<ChoiceResponseDto>()
            {
                new()
                {
                    Choice = "Apple",
                    Votes = 0
                },
                new()
                {
                    Choice = "Amazon",
                    Votes = 0
                }
            };

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            body.Choices.Should().BeEquivalentTo(expectedChoices);
            body.ImageUrl.Should().Be(request.ImageUrl);
            body.Question.Should().Be(request.Question);
            body.ThumbUrl.Should().Be(request.ThumbUrl);
            body.Id.Should().NotBe(0);
        }

        [Fact]
        public async Task Post_to_questions_returns_400_when_passing_valid_data()
        {
            var request = new QuestionCreatedRequestDto
            {
                Choices = new List<string>() { "Apple", "Amazon" },
                ImageUrl = "http://image.com",
                ThumbUrl = "http://thumb.com"
            };

            var response = await HttpClient.PostAsync("questions", request.ToJsonContent());
            var body = await response.Content.ReadAsAsync<ProblemDetails>();


            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            body.Title.Should().Be(Resource.OneOrMoreValidationErrorsOccurred);
            body.Detail.Should().Be(Resource.PleaseReferToTheErrorsPropertyForAdditionalDetails);
        }

        [Fact]
        public async Task Get_to_questions_returns_200()
        {
            await CreateQuestions(10);

            var response = await HttpClient.GetAsync("questions");
            var body = await response.Content.ReadAsAsync<PaginatedQuestionResponseDto>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            body.TotalItems.Should().Be(10);
            body.Questions.Should().HaveCount(10);
        }

        [Fact]
        public async Task Get_to_questions_returns_200_when_passing_correct_question_id()
        {
            var question = new Questions("Favourite programming language?",
                "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)");

            var choices = new List<string>
            {
                "Swift",
                "Python",
                "Objective-C",
                "Ruby"
            };

            question.AddChoices(choices);

            await _questionRepository.Add(question);


            var response = await HttpClient.GetAsync($"questions/{question.Id}");
            var body = await response.Content.ReadAsAsync<QuestionResponseDto>();

            var expectedChoices = new List<ChoiceResponseDto>()
            {
                new()
                {
                    Choice = "Swift",
                    Votes = 0
                },
                new()
                {
                    Choice = "Python",
                    Votes = 0
                },
                new()
                {
                    Choice = "Objective-C",
                    Votes = 0
                },
                new()
                {
                    Choice = "Ruby",
                    Votes = 0
                }
            };

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            body.Choices.Should().BeEquivalentTo(expectedChoices);
            body.ImageUrl.Should().Be(question.ImageUrl);
            body.Question.Should().Be(question.Question);
            body.ThumbUrl.Should().Be(question.ThumbUrl);
            body.Id.Should().Be(question.Id);
        }

        [Fact]
        public async Task Put_to_questions_returns_200_when_passing_valid_data()
        {
            var question = new Questions("Favourite programming language?",
               "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
               "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)");

            var choices = new List<string>
            {
                "Swift",
                "Python",
            };

            question.AddChoices(choices);
            await _questionRepository.Add(question);

            var request = new QuestionUpdatedRequestDto
            {
                Choices = new List<ChoiceRequestDto>()
                {
                    new()
                    {
                       Choice = "Swift",
                       Votes = 15
                    },
                     new()
                    {
                       Choice = "Python",
                       Votes = 15
                    },
                },
                ImageUrl = "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                Question = "Favourite programming language?",
                ThumbUrl = "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)"
            };

            var response = await HttpClient.PutAsync($"questions/{question.Id}", request.ToJsonContent());
            var body = await response.Content.ReadAsAsync<QuestionResponseDto>();

            var expectedChoices = new List<ChoiceResponseDto>()
            {
                new()
                {
                    Choice = "Swift",
                    Votes = 15
                },
                new()
                {
                    Choice = "Python",
                    Votes = 15
                }
            };

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            body.Choices.Should().BeEquivalentTo(expectedChoices);
            body.ImageUrl.Should().Be(request.ImageUrl);
            body.Question.Should().Be(request.Question);
            body.ThumbUrl.Should().Be(request.ThumbUrl);
            body.Id.Should().NotBe(0);
        }

        [Fact]
        public async Task Put_to_questions_returns_400_when_passing_valid_data()
        {
            var question = new Questions("Favourite programming language?",
               "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
               "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)");

            var choices = new List<string>
            {
                "Swift",
                "Python",
            };

            question.AddChoices(choices);
            await _questionRepository.Add(question);

            var request = new QuestionUpdatedRequestDto
            {
                Choices = new List<ChoiceRequestDto>()
                {
                    new()
                    {
                       Choice = "Swift",
                       Votes = 15
                    },
                     new()
                    {
                       Choice = "Python",
                       Votes = 15
                    },
                },
                ImageUrl = "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                ThumbUrl = "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)"
            };

            var response = await HttpClient.PutAsync($"questions/{question.Id}", request.ToJsonContent());
            var body = await response.Content.ReadAsAsync<ProblemDetails>();

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            body.Title.Should().Be(Resource.OneOrMoreValidationErrorsOccurred);
            body.Detail.Should().Be(Resource.PleaseReferToTheErrorsPropertyForAdditionalDetails);
        }

        private async Task CreateQuestions(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var question = new Questions("Favourite programming language?",
               "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
               "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)");

                var choices = new List<string>
                {
                    "Swift",
                    "Python",
                    "Objective-C",
                    "Ruby"
                };

                question.AddChoices(choices);

                await _questionRepository.Add(question);
            }

        }
    }
}
