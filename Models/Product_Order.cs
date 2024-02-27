using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace مشروع_التخرج.Models
{
    public class Product_Order
    {
        [Key]
        [Required]
        public int Order_Id { get; set; }
        [Required]
        public string Order_status { get; set; }
        [Required]
        public DateTime data { get; set; }
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
