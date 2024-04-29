using System.ComponentModel.DataAnnotations;

namespace TechNeuron_Assignment.Models
{
	public class Employee
	{
        [Key]
        public int EmployeeID { get; set; }
        [Display(Name ="Employee Name")]
        [Required(ErrorMessage ="Employee Name is Required")]
        [StringLength(20)]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage ="Employee Description is Required")]
        [StringLength(30)]
        [Display(Name ="Employee Description")]
        public string EmployeeDescription { get; set; }
        [Display(Name = "Employee Age")]
        [Required(ErrorMessage ="Employee Age is Required")]        
        public int EmployeeAge { get; set; }
        [Required(ErrorMessage ="Employee Address is Required")]
        [StringLength (100)]
        public string EmployeeAddress { get; set; }
    }
}
