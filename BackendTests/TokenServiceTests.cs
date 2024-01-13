using FeedbackApp.Server.Data;
using FeedbackApp.Server.Models;
using FeedbackApp.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BackendTests
{
    public class TokenServiceTests
    {
        private readonly TokenService _tokenService;
        public TokenServiceTests() 
        {
            _tokenService = new TokenService();
        }

        [Fact]
        public void TokenService_ShouldReturnToken()
        {
            var user = new User {
                EmailAddress = "Test@Email.com",
                Password = "password",
                Role = Role.User,
                Id = "1",
            };
            var token = _tokenService.CreateToken(user);

            Assert.NotNull(user);
        }
    }
}
