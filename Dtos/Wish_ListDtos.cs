using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using مشروع_التخرج.Models;

namespace مشروع_التخرج.Dtos
{
    public class Wish_ListDtos
    {

        public int W_Id { get; set; }
        [Required]

        public DateTime data { get; set; }

        

    }
}
