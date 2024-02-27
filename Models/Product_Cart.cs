using System.ComponentModel.DataAnnotations;

namespace مشروع_التخرج.Models
{
    public class Product_Cart
    {
        [Key]
        [Required]
        public int P_Id { get; set; }
        [Required]
        [Key]
        public int Cart_Id { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }

    }
}
