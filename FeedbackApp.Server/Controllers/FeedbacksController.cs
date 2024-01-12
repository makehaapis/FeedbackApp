using FeedbackApp.Server.Data;
using FeedbackApp.Server.Models;
using FeedbackApp.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IFeedbacksService _service;

        public FeedbacksController(AppDbContext context, IFeedbacksService service)
        {
            _context = context;
            _service = service;
        }

        //GET: api/feedbacks
        [HttpGet]
        public async Task<IActionResult> GetFeedbacks()
        {
            var allFeedbacks = await _service.GetAllAsync();
            return Ok(allFeedbacks);
        }

        // POST: api/Feedbacks
        [HttpPost]  
        public async Task<ActionResult> PostFeedback(Feedback feedback)
        {
            await _service.AddAsync(feedback);
            return Ok(feedback);
        }

        // DELETE: api/Feedbacks/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var feedback = await _service.GetByIdAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}