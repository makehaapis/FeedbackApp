using System.ComponentModel.DataAnnotations;

namespace FeedbackApp.Server.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        public int Rating { get; set; }
        public string Secret { get; set; }
    }
}
