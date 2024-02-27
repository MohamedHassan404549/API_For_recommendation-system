using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace مشروع_التخرج.Dtos
{
    public class Product_OrderDtos
    {
        [Required]

        public string Order_status { get; set; }
        public DateTime data { get; set; }
        [Required]

        [ForeignKey("Cus_Id")]
        public int Cus_Id { get; set; }
        [Required]

        [ForeignKey("P_Id")]
        public int P_Id { get; set; }
    }
}
