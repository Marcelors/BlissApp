using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Api;
using Application.DTOs;
using FluentAssertions;
using Globalization;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Integration
{
    [Collection("API-TESTS")]
    public class QuestionApiTests : IntegrationTestFixture
    {
        public QuestionApiTests(TestingWebApplicationFactory<Startup> factory) : base(factory)
        {
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
        public async Task Get_to_questions_returns_200_when_passing_correct_question_id()
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
        public async Task Put_to_questions_returns_200_when_passing_valid_data()
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
        public async Task Put_to_questions_returns_400_when_passing_valid_data()
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
            body.Title.Should().Be("");
            body.Detail.Should().Be("");
        }
    }
}
