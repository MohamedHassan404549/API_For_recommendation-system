using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace مشروع_التخرج.Dtos
{
    public class ProductDtos
    {
        //public int P_Id { get; set; }
        [Required]

        public string P_Name { get; set; }
        [Required]

        public string P_Description { get; set; }
        [Required]

        public IFormFile? p_Image { get; set; }
        [Required]
        public decimal P_Price { get; set; }
        [Required]
        public int P_Quantity { get; set; }
        [Required]
        [ForeignKey("Admin_Id")]
        public int Admin_Id { get; set; }
        [Required]
        [ForeignKey("Sub_C_Id")]
        public int Sub_C_Id { get; set; }

        
    }
}
