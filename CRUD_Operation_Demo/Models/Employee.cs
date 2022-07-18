using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Operation_Demo.Models
{
    [Table("Emp_Details")]
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]  
        [DataType(DataType.Text)]  
        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Employee Gender is required")]
        [DataType(DataType.Text)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Employee Department is required for Salary structure")]
        [DataType(DataType.Text)]
        public string Department { get; set; }

        //[DataType(DataType.Currency)]
        public double Salary { get; set; }

        [Required(ErrorMessage ="Age must be required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Mobile number must be required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please Enter a valid Phone Number")]
        public string Mobile_No { get; set; }

        [Required(ErrorMessage = "Email Id must be required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter a valid Email Address ")]
        public string Email_Id { get; set; }

        public string City { get; set; }
    }
}
