using System.ComponentModel.DataAnnotations;

namespace TechNeuron_Assignment.Models
{
	public class EmployeeTask
	{
        [Key]
        public int TaskID { get; set; }
        [Required(ErrorMessage ="Task Name is Required")]
        [StringLength(50)]
        [Display(Name ="Name of Task")]
        public string TaskName { get; set; }
        [Required(ErrorMessage ="Task Description is Required")]
        [StringLength(100)]
        [Display(Name ="Description about Task")]
        public string TaskDescription { get; set; }
    }
}
