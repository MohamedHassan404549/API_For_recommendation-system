using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace مشروع_التخرج.Dtos
{
    public class Bundle_OrdersDtos
    {
        [Required]

        public string Order_status { get; set; }
        [NotMapped]
        [Required]

        public DateTime data { get; set; }

        [Required]

        [ForeignKey("Bundle_Id")]
        public int Bundle_Id { get; set; }
        [Required]

        [ForeignKey("Cus_Id")]
        public int Cus_Id { get; set; }
    }
}
