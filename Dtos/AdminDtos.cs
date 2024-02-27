using System.ComponentModel.DataAnnotations;

namespace مشروع_التخرج.Dtos
{
    public class AdminDtos
    {
        public int Admin_Id { get; set; }

        [Required(ErrorMessage = "Admin Name is required.")]
        public string Admin_Name { get; set; }

        [Required(ErrorMessage = "Admin Type is required.")]
        public string Admin_Type { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address. The email should be like Mohamed12@gmail.com")]
        public string Admin_Email { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "Admin Password is required.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password must contain at least one letter, one number, and be at least 8 characters long.")]
        public string Admin_Password { get; set; }
    }
}
