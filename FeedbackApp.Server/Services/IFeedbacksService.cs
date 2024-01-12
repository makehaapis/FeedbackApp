using FeedbackApp.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FeedbackApp.Server.Services
{
    public interface IFeedbacksService
    {
        Task<IEnumerable<Feedback>> GetAllAsync();
        Task AddAsync(Feedback feedback);
        Task DeleteAsync(int id);
        Task<Feedback> GetByIdAsync(int id);
    }
}
