using TechNeuron_Assignment.Models;

namespace TechNeuron_Assignment.Repositories
{
	public interface IEmployeeRepository
	{
		Employee Add(Employee employee);
		Employee Update(Employee employee);
		Employee Delete(int id);
		Employee GetEmployee(int id);
		IEnumerable<Employee> GetAll();
	}
}
