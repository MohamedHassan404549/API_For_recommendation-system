using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace مشروع_التخرج.Models
{
    public class Bundle_Review
    {
        [Key]
        [Required]
        public int B_Review_Id { get; set; }
        
        public string B_Review_Comment { get; set; }
       
        public int Reting { get; set; }
        [Required]
        [ForeignKey("Cus_Id")]
        public int Cus_Id { get; set; }
        public Customer Customer { get; set; }
        [Required]
        [ForeignKey("Bundle_Id")]
        public int Bundle_Id { get; set; }
        public Bundle Bundle { get; set; }
    }
}
