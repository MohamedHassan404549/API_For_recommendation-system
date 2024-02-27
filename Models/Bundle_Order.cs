using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace مشروع_التخرج.Models
{
    public class Bundle_Order
    {
        [Key]
        [Required]
        public int B_Order_Id { get; set; }
        [Required]
        public string Order_status { get; set; }
        [Required]
        public DateTime data { get; set; }

        [Required]
        [ForeignKey("Bundle_Id")]
        public int Bundle_Id { get; set; }

        [Required]
        [ForeignKey("Cus_Id")]
        public int Cus_Id { get; set; }
        public Bundle Bundle { get; set; }
        public Customer Customer { get; set; }
    }
}
