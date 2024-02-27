using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace مشروع_التخرج.Models
{
    public class Product_Review
    {
        [Key]
        [Required]
        public int Review_Id { get; set; }
        
        public string comment { get; set; }
       
        public int rating { get; set; }
        [Required]
        [ForeignKey("Cus_Id")]
        public int Cus_Id { get; set; }
        public Customer Customer { get; set; }

        [Required]
        [ForeignKey("P_Id")]
        public int P_Id { get; set; }
        public Product Product { get; set; }
    }
}
