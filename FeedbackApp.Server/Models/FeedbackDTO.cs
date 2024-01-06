using System.ComponentModel.DataAnnotations;

namespace FeedbackApp.Server.Models
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
