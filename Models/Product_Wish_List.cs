using System.ComponentModel.DataAnnotations;

namespace مشروع_التخرج.Models
{
    public class Product_Wish_List
    {
        [Key]
        [Required]
        public int W_Id { get; set; }
        [Key]
        [Required]
        public int P_Id { get; set; }

    
        public Wish_List Wish_List { get; set; }
        public Product Product { get; set; }
    }
}
