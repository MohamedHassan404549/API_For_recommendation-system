using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using مشروع_التخرج.Models;

namespace مشروع_التخرج.Dtos
{
    public class BundleDtos
    {

        public int Bundle_Id { get; set; }
        [Required]

        public int Bundle_Price { get; set; }
        [Required]
        public IFormFile? Bundle_image { get; set; }
        [Required]

        public string Bundle_Description { get; set; }
        [Required]
        [ForeignKey("Admin_Id")]
        public int Admin_Id { get; set; }

    }
}
