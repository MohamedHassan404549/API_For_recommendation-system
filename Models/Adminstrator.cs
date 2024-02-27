using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using مشروع_التخرج.Dtos;

namespace مشروع_التخرج.Models
{
    public class Adminstrator
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        
        public int Admin_Id { get; set; }
    
        public string Admin_Name { get; set; }
    
        public string Admin_Type { get; set; }
        
        public string Admin_Email { get; set;}
  
        public string Admin_Password { get; set;}


       
        public virtual ICollection<Product> Products { get; set; }
        
        public virtual ICollection<Category> Categories { get; set; }
       
        public virtual ICollection<Bundle> Bundles { get; set; }
        public virtual ICollection<SubCatagory> SubCatagories { get; set; }


    }
    
}
