using System.ComponentModel.DataAnnotations;

namespace مشروع_التخرج.Models
{
    public class Bundle_Wish_List
    {
        [Key]
        [Required]
        public int W_Id { get; set; }

        [Key]
        [Required]
        public int Bundle_Id { get; set; }
        public Wish_List Wish_List { get; set; }
        public Bundle Bundle { get; set; }
    }
}
