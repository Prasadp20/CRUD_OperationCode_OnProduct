using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Operation_Demo.Models
{
    [Table("Product_Details")] // this model class show the which sql table show this code
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]  //if our column is not Identity then do not use this model class
        public int Id { get; set; }


        [Required(ErrorMessage ="Product Name is required")] // it gives error msg if user dont put name
        [DataType(DataType.Text)]  // it shows the data must in text formate
        [Display(Name ="Product Name")]  // it shows the column name is "Product Name"
        public string Name { get; set; }

        [Required(ErrorMessage ="Price is required")]
        [Display(Name ="Product Price")]
        [Range(minimum:10, maximum:1000)]  // it gives the restriction on price it should be in between 10 to 1000
        public double Price { get; set; }
    }
}
