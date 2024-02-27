using System.ComponentModel.DataAnnotations;

namespace مشروع_التخرج.Dtos
{
    public class CartDtos
    {
        [Required]

        public int Cart_Id { get; set; }
        [Required]

        public int Cart_Quantity { get; set; }
        [Required]

        public decimal Cart_Total_Price { get; set; } = decimal.Zero;
    }
}
