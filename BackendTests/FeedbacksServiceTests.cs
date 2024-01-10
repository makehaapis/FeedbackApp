using FeedbackApp.Server.Controllers;
using FeedbackApp.Server.Data;
using FeedbackApp.Server.Models;
using FeedbackApp.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.Protected;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace BackendTests
{
    public class FeedbacksServiceTests
    {
        private FeedbacksService feedbackService;
        private readonly AppDbContext _context;
        private readonly ITestOutputHelper output;

        public FeedbacksServiceTests(ITestOutputHelper output)
        {
                feedbackService = new FeedbacksService(_context);
                this.output = output;
        }

        [Fact]
        public void GetFeedbacks()
        {
            //Arrange

            //Act
            var feedbacks = feedbackService.GetAllAsync();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(feedbacks);
            });
        }

        [Fact]
        public void GetFeedbackId()
        {
            //Arrange
            int id = 1;

            //Act
            var feedback = feedbackService.GetByIdAsync(id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(feedback);
                Assert.Equal(1, feedback.Id);
            });
        }

        [Fact]
        public void AddFeedback()
        {
            //Arrange
            Feedback feedback = new Feedback()
            {
                Id = 100,
                Name = "New User",
                Email = "test@email.com",
                Description = "Description",
                Rating = 4
            };

            //Act
            var data = feedbackService.AddAsync(feedback);
            var expectedData = feedbackService.GetByIdAsync(feedback.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(data);
                Assert.NotNull(expectedData);
                Assert.Equal(expectedData.Id, expectedData.Id);
            });
        }
    }
}