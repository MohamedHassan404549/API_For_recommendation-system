using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace مشروع_التخرج.Dtos
{
    public class Bundle_ReviewDtos
    {
        public string B_Review_Comment { get; set; }
        public int Reting { get; set; }
        [Required]

        [ForeignKey("Cus_Id")]
        public int Cus_Id { get; set; }
        [Required]

        [ForeignKey("Bundle_Id")]
        public int Bundle_Id { get; set; }
    }
}
