using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace مشروع_التخرج.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int P_Id { get; set; }
        [Required]
        public string P_Name { get; set;}
        [Required]
        public string P_Description { get; set;}
        [Required]
      
        public byte[] p_Image { get; set; }
        [Required]
        public decimal P_Price { get; set; }
        [Required]
        public int P_Quantity { get; set; }
        [Required]
        [ForeignKey("Admin_Id")]
        public int Admin_Id { get; set; }
        public Adminstrator Adminstrator { get; set; }

        [Required]
        [ForeignKey("Sub_C_Id")]
        public int Sub_C_Id { get; set; }
        public SubCatagory SubCatagory { get; set; }




        public virtual ICollection<Product_Wish_List> product_Wish_Lists { get; set; }
        public virtual ICollection<Product_Bundle> product_Bundles { get; set; }
        public virtual ICollection<Product_Cart> product_Carts { get; set; }
        public virtual ICollection<Product_Order> Product_Orders { get; set; }
        public virtual ICollection<Product_Review> Product_Reviews { get; set; }


    }
}
