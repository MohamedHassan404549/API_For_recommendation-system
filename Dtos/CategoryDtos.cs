using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace مشروع_التخرج.Dtos
{
    public class CategoryDtos
    {
        public int C_Id { get; set; }
        [Required]
        public string C_Name { get; set; }
        [Required]
        public string C_Description { get; set; }
        [Required]
        public IFormFile? C_Image { get; set; }
        [Required]
        [ForeignKey("Admin_Id")]
        public int Admin_Id { get; set; }
    }
}
