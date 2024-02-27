using System.ComponentModel.DataAnnotations;

namespace مشروع_التخرج.Models
{
    public class Product_Bundle
    {
        [Key]
        [Required]
        public int P_Id { get; set; } 

        [Key]
        [Required]
        public int Bundle_Id { get; set; }
        public Product Product { get; set; }
        public Bundle Bundle { get; set; }
     
    }
}
