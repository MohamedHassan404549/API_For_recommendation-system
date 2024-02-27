using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace مشروع_التخرج.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int Cus_Id { get; set; }
        [Required]
        public string Cus_firstName { get; set; }
        [Required]
        public string Cus_lastName { get; set; }
        public string Cus_phone { get; set; }
        [Required]
        public string Cus_Email { get; set; }
        [Required]
        public string Cus_Passaword { get; set; }
        [Required]
        public string Cus_Country { get; set; }
        [Required]
        public string Cus_City { get; set; }
        [Required]
        public string Cus_Street { get; set; }
        [Required]

        [ForeignKey("Cart_Id")]
        public int Cart_Id { get; set; }
        public Cart Cart { get; set; }
        [Required]
        [ForeignKey("W_Id")]
        public int W_Id { get; set; }
        public Wish_List Wish_List { get; set; }


        public virtual ICollection<Bundle_Order> Bundle_Orders { get; set; }
        public virtual ICollection<Bundle_Review> Bundle_Reviews { get; set; }
        public virtual ICollection<Product_Order> Product_Orders { get; set; }
        public virtual ICollection<Product_Review> Product_Reviews { get; set; }
       


    }
}
