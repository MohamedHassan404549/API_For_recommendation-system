using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace مشروع_التخرج.Dtos
{
    public class SubCategoryDtos
    {
        public int Sub_C_Id { get; set; }
        [Required]
        public IFormFile? Sub_C_image { get; set; }
        [Required]
        public string sub_c_Description { get; set; }
        [Required]

        [ForeignKey("Admin_Id")]
        public int Admin_Id { get; set; }
        [Required]

        [ForeignKey("C_Id")]
        public int C_Id { get; set; }
    }
}
