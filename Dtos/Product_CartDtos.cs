using System.ComponentModel.DataAnnotations;

namespace مشروع_التخرج.Dtos
{
    public class Product_CartDtos
    {
        [Required]

        [Key]
        public int P_Id { get; set; }

        [Key]
        [Required]

        public int Cart_Id { get; set; }
    }
}
