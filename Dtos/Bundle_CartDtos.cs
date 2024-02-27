using System.ComponentModel.DataAnnotations;

namespace مشروع_التخرج.Dtos
{
    public class Bundle_CartDtos
    {
        [Key]
        [Required]
        public int Bundle_Id { get; set; }
        [Key]
        [Required]
        public int Cart_Id { get; set; }
    }
}
