using Microsoft.EntityFrameworkCore;
using TechNeuron_Assignment.Models;

namespace TechNeuron_Assignment.Data
{
	public class ApplicationDbContext :DbContext
	{
        //Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        //Dbset Properties
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> Tasks { get; set; }

    }
}
