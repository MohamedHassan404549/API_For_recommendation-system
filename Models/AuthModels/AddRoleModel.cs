using System.ComponentModel.DataAnnotations;

namespace مشروع_التخرج.Models.Class
{
    public class AddRoleModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}