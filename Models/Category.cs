using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace مشروع_التخرج.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int C_Id { get; set; }
        [Required]
        public string C_Name { get; set;}
        [Required]
        
        public byte[] C_Image { get; set; }
        [Required]
        public string C_Description { get; set;}
        [Required]

        [ForeignKey("Admin_Id")]
        public int Admin_Id { get; set; }
        public Adminstrator Adminstrator { get; set; }

        public virtual ICollection<SubCatagory> SubCatagories { get; set;}
        
    }
}
