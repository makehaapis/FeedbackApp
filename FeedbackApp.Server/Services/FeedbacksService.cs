using FeedbackApp.Server.Data;
using FeedbackApp.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FeedbackApp.Server.Services
{
    public class FeedbacksService : IFeedbacksService
    {
        private readonly AppDbContext _context;
        public FeedbacksService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync() => await _context.Set<Feedback>().ToListAsync();

        public async Task AddAsync(Feedback feedback)
        {
            await _context.Set<Feedback>().AddAsync(feedback);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var feedback = await _context.Set<Feedback>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<Feedback>(feedback);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Feedback> GetByIdAsync(int id) => await _context.Set<Feedback>().FirstOrDefaultAsync(n => n.Id == id);
    }
}
