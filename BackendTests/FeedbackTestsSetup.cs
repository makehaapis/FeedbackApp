using FeedbackApp.Server.Data;
using FeedbackApp.Server.Models;
using FeedbackApp.Server.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace BackendTests
{
    public sealed class FeedbackTestsSetup : XunitTestFramework, IDisposable
    {
        private FeedbacksService feedbackService;
        private readonly AppDbContext _context;
        public FeedbackTestsSetup(IMessageSink messageSink) : base(messageSink)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                            .UseSqlServer("Data Source=DESKTOP-87R64IG\\SQLEXPRESS;Initial Catalog=FeedBackAppTestsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                            .Options;

            _context = new AppDbContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.Migrate();
            feedbackService = new FeedbacksService(_context);
            if (!_context.Feedbacks.Any())
            {
                _context.Feedbacks.RemoveRange(_context.Feedbacks);
                _context.SaveChanges();
            }

            _context.Feedbacks.AddRange(new List<Feedback>()
            {
                new()
                {
                    Name = "John",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas elit lectus, eleifend at nunc non, rhoncus lobortis nulla. Donec efficitur ornare suscipit. Vestibulum dapibus sed magna id ullamcorper. Nunc vel eros et quam volutpat venenatis et eget neque. Cras lacinia turpis erat. Curabitur at scelerisque ligula. Sed cursus turpis nec eros consectetur, et suscipit dui facilisis. Donec congue, nunc posuere blandit mattis, est eros dapibus magna, porta volutpat nisl est ut arcu. Maecenas justo.",
                    Email = "john@gmail.com",
                    Created = DateTime.Now,
                    Rating = 5
                },
                new()
                {
                    Name = "Steve",
                    Description = "Vivamus sed lectus eros. Praesent faucibus, turpis quis luctus sollicitudin.",
                    Email = "steve@gmail.com",
                    Created = DateTime.Now,
                    Rating = 4
                    },
                new()
                {
                    Name = "Adeline",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam eros turpis, tempus eu lacus non.",
                    Email = "adelene@gmail.com",
                    Rating = 2
                },
                new()
                {
                    Name = "Holly",
                    Description = "Sed viverra ex leo, a integer.",
                    Email = "holly@gmail.com",
                    Rating = 5
                },
                new()
                {
                    Name = "Karol",
                    Description = "Maecenas imperdiet pulvinar ex, ut mattis massa. Sed ut augue eu lorem dignissim ullamcorper. Nam ultrices augue non hendrerit congue. Integer malesuada tortor ornare suscipit venenatis. Fusce iaculis leo sem.",
                    Email = "karol@gmail.com",
                    Rating = 2
                }});

            _context.SaveChanges();
        }
        public new void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
