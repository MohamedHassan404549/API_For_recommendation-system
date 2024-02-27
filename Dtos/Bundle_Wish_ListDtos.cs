using System.ComponentModel.DataAnnotations;

namespace مشروع_التخرج.Dtos
{
    public class Bundle_Wish_ListDtos
    {
        [Key]
        [Required]

        public int W_Id { get; set; }

        [Key]
        [Required]

        public int Bundle_Id { get; set; }
    }
}
