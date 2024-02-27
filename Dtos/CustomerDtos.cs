using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace مشروع_التخرج.Dtos
{
    public class CustomerDtos
    {
        public int Cus_Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
        public string Cus_firstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
        public string Cus_lastName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be a 10-digit number.")]
        public string Cus_phone { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address. The email should be like Mohamed12@gmail.com")]
        public string Cus_Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter and one number.")]
        public string Cus_Passaword { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string Cus_Country { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string Cus_City { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        public string Cus_Street { get; set; }
        [Required]

        [ForeignKey("Cart_Id")]
        public int Cart_Id { get; set; }
        [Required]

        [ForeignKey("W_Id")]
        public int W_Id { get; set; }
    }
}
