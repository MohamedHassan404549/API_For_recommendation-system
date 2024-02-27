using System.ComponentModel.DataAnnotations;

namespace مشروع_التخرج.Models.Class
{
    public class TokenRequestModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}