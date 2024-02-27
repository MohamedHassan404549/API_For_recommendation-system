using System.ComponentModel.DataAnnotations;

namespace مشروع_التخرج.Dtos
{
    public class Product_BundleDtos
    {
        [Key]
        [Required]
        public int P_Id { get; set; }

        [Key]
        [Required]

        public int Bundle_Id { get; set; }
    }
}
