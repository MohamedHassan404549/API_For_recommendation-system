using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace مشروع_التخرج.Models
{
    public class Bundle
    {
        [Key]
        [Required]
        public int Bundle_Id { get; set; }
        [Required]
        public int Bundle_Price { get; set;}
        [Required]
        [RegularExpression(@"(.*\.png$)|(.*\.jpg$)", ErrorMessage = "Image must be in JPG or PNG format")]
        public byte[] Bundle_image { get; set;}
        [Required]
        public string Bundle_Description { get; set;}
        [Required]

        [ForeignKey("Admin_Id")]
        public int Admin_Id { get; set; }
        public Adminstrator Adminstrator { get; set; }


        public virtual ICollection<Product_Bundle> product_Bundles { get; set; }
        public virtual ICollection<Bundle_Cart> Bundle_Carts { get; set; }
        public virtual ICollection<Bundle_Order> Bundle_Orders { get; set; }
        public virtual ICollection<Bundle_Review> Bundle_Reviews { get; set; }
        public virtual ICollection<Bundle_Wish_List> Bundle_Wish_Lists { get; set; }
    }
}
