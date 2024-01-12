using FeedbackApp.Server.Data;
using FeedbackApp.Server.Models;
using FeedbackApp.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FeedbackApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public LoginController(UserManager<User> userManager, AppDbContext context, TokenService tokenService, ILogger<LoginController> logger)
        {
            _userManager = userManager;
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, request.Password);
                if (passwordCheck)
                {
                    var accessToken = _tokenService.CreateToken(user);
                    await _context.SaveChangesAsync();

                    return Ok(new AuthResponse
                    {
                        Email = user.EmailAddress,
                        Token = accessToken,
                    });
                }
            }
            return BadRequest("Bad credentials");
        }
    }
}