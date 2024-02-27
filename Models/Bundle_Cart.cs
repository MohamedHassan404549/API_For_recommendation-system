using System.ComponentModel.DataAnnotations;

namespace مشروع_التخرج.Models
{
    public class Bundle_Cart
    {
        [Key]
        [Required]
        public int Bundle_Id { get; set; }
        public Bundle Bundle { get; set; }
        [Key]
        [Required]
        public int Cart_Id { get; set; }
        public Cart Cart { get; set; }
       
    }
}
