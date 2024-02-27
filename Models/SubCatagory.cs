using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace مشروع_التخرج.Models
{
    public class SubCatagory
    {
        [Key]
        [Required]
        public int Sub_C_Id { get; set; }
        [Required]
        public byte[] Sub_C_image { get; set; }
        [Required]
        public string sub_c_Description { get; set; }
        [Required]

        [ForeignKey("Admin_Id")]
        public int Admin_Id { get; set; }
        public Adminstrator Adminstrator { get; set; }
        [Required]

        [ForeignKey("C_Id")]
        public int C_Id { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
