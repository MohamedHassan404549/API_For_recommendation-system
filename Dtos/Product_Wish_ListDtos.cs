using System.ComponentModel.DataAnnotations;

namespace مشروع_التخرج.Dtos
{
    public class Product_Wish_ListDtos
    {
        [Key]
        [Required]

        public int W_Id { get; set; }
        [Key]
        [Required]

        public int P_Id { get; set; }
    }
}
