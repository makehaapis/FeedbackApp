using FeedbackApp.Server.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace FeedbackApp.Server.Models
{
    public class User: IdentityUser
    {
        [Required(ErrorMessage = "Email addres is required")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Role Role { get; set; }

    }
}
