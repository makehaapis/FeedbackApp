using Baseline.Reflection;
using FeedbackApp.Server.Controllers;
using FeedbackApp.Server.Data;
using FeedbackApp.Server.Models;
using FeedbackApp.Server.Services;
using ImTools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;
namespace BackendTests
{
    public class FeedbackServiceTests : IDisposable
    {
        private readonly AppDbContext _testcontext;
        private readonly FeedbacksService _service;
        private readonly FeedbacksController _controller;

        public FeedbackServiceTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("")
                .Options;

            _testcontext = new AppDbContext(options);
            _testcontext.Database.EnsureDeleted();
            _testcontext.Database.Migrate();

            _service = new FeedbacksService(_testcontext);
            _controller = new FeedbacksController(_testcontext, _service);
        }

        public void Dispose()
        {
            _testcontext.Database.EnsureDeleted();
            _testcontext.Dispose();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAll()
        {
            _testcontext.Feedbacks.AddRange(Enumerable.Range(1, 5).Select(x => new Feedback
            {
                Name = $"Name {x}",
                Description = $"Description {x}",
                Email = $"Email {x}",
                Rating = x
            }));

            await _testcontext.SaveChangesAsync();

            var feedbacks = await _service.GetAllAsync();

            Assert.Equal(5, feedbacks.Count());
        }

        [Fact]
        public async void WhenFeedbackAdded_CountShouldBeOne()
        {
            await _service.AddAsync(new Feedback
            {
                Name = "Name",
                Description = "Description",
                Email = "email@email.co",
                Rating = 1
            });

            await _testcontext.SaveChangesAsync();

            var feedbacks = await _service.GetAllAsync();

            Assert.Equal(1, feedbacks.Count());
        }

        [Fact]
        public async void WhenFeedbackWithoutDesciprtionAdded_ShouldThrowDbException()
        {
            await Assert.ThrowsAsync<DbUpdateException>(async () => await _service.AddAsync(new Feedback
            {
                Name = "Name",
                Email = "email@email.co",
                Rating = 1
            }));
            
        }

        [Fact]
        public async void WhenFeedbackWithoutEmailAdded_ShouldThrowDbException()
        {
            await Assert.ThrowsAsync<DbUpdateException>(async () => await _service.AddAsync(new Feedback
            {
                Name = "Name",
                Description = "Description",
                Rating = 1
            }));
        }

        [Fact]
        public async void WhenFeedbackWithoutNameAdded_ShouldThrowDbException()
        {
            await Assert.ThrowsAsync<DbUpdateException>(async () => await _service.AddAsync(new Feedback
            {
                Email = "email@email.com",
                Description = "Description",
                Rating = 1
            }));
        }
    }
}
