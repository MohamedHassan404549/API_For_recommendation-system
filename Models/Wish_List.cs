using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace مشروع_التخرج.Models
{
    public class Wish_List
    {
        [Key]
        [Required]
        public int W_Id { get; set; }
        [Required]
        public DateTime data { get; set; }


        public virtual ICollection<Customer> customers { get; set; }
        public virtual ICollection<Product_Wish_List> product_Wish_Lists { get; set; }
       
        public virtual ICollection<Bundle_Wish_List> Bundle_Wish_Lists { get; set; }


    }
}
