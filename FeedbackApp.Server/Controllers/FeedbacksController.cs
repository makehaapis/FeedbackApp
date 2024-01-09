using FeedbackApp.Server.Data;
using FeedbackApp.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FeedbacksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Feedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackDTO>>> GetFeedbacks()
        {
            return await _context.Feedbacks
                .Select(f => FeedbackToDTO(f))
                .ToListAsync();
        }

        // POST: api/Feedbacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]  
        public async Task<ActionResult<FeedbackDTO>> PostFeedback(FeedbackDTO feedbackDTO)
        {
            var feedback = new Feedback
            {
                Name = feedbackDTO.Name,
                Description = feedbackDTO.Description,
                Email = feedbackDTO.Email,
                Created = DateTime.Now,
                Rating = feedbackDTO.Rating
        };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return FeedbackToDTO(feedback);
        }

        // DELETE: api/Feedbacks/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            Console.WriteLine($"Poistetaan:{id}");
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private static FeedbackDTO FeedbackToDTO(Feedback feedback) =>
            new FeedbackDTO
            {
                Id = feedback.Id,
                Name = feedback.Name,
                Description = feedback.Description,
                Email = feedback.Email,
                Created = feedback.Created,
                Rating = feedback.Rating
            };
    }
}