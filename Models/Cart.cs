using System.ComponentModel.DataAnnotations;

namespace مشروع_التخرج.Models
{
    public class Cart
    {
        [Key]
        [Required]
        public int Cart_Id { get; set; }
        [Required]
        public int Cart_Quantity { get; set; }
        [Required]
        public decimal Cart_Total_Price { get; set; } = decimal.Zero;


        public virtual ICollection<Bundle_Cart> bundle_Carts { get; set; }
        public virtual ICollection<Product_Cart> product_Carts { get; set;}
        public virtual ICollection<Customer> Customers { get; set; }

    }
}
