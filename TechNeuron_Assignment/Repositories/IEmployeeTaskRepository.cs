using TechNeuron_Assignment.Models;

namespace TechNeuron_Assignment.Repositories
{
	public interface IEmployeeTaskRepository
	{
		EmployeeTask Add(EmployeeTask employeeTask);
		EmployeeTask Update(EmployeeTask employeeTask);
		EmployeeTask Delete(int id);
		EmployeeTask GetEmployeeTask(int id);
		IEnumerable<EmployeeTask> GetAll();
	}
}
