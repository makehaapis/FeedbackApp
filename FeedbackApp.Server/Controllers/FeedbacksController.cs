using FeedbackApp.Server.Data;
using FeedbackApp.Server.Models;
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

        // GET: api/Feedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackDTO>> GetFeedback(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);

            if (feedback == null)
            {
                return NotFound();
            }

            return FeedbackToDTO(feedback);
        }

        // PUT: api/Feedbacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback(int id, FeedbackDTO feedbackDTO)
        {
            if (id != feedbackDTO.Id)
            {
                return BadRequest();
            }

            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }

            feedback.Name = feedbackDTO.Name;
            feedback.Description = feedbackDTO.Description;
            feedback.Email = feedbackDTO.Email;
            feedback.Created = feedbackDTO.Created;
            feedback.Rating = feedbackDTO.Rating;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!FeedbackExists(id))
            {
                return NotFound();
            }

            return NoContent();
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

            return CreatedAtAction(
                nameof(GetFeedback),
                new { id = feedback.Id },
                FeedbackToDTO(feedback));
        }

        // DELETE: api/Feedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedbackExists(int id)
        {
            return _context.Feedbacks.Any(e => e.Id == id);
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