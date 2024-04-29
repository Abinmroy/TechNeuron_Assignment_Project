using Microsoft.EntityFrameworkCore;
using TechNeuron_Assignment.Data;
using TechNeuron_Assignment.Models;

namespace TechNeuron_Assignment.Repositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly ApplicationDbContext _Context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _Context = context;
        }
        public Employee Add(Employee employee)
		{
			_Context.Employees.Add(employee);
			_Context.SaveChanges();
			return employee;					
		}

		public Employee Delete(int id)
		{
			Employee employee = _Context.Employees.Find(id);
			if (employee != null)
			{
				_Context.Employees.Remove(employee);
				_Context.SaveChanges();
			}
			return employee;			
		}

		public IEnumerable<Employee> GetAll()
		{
			return _Context.Employees;
		}

		public Employee GetEmployee(int id)
		{
			return _Context.Employees.Find(id);
		}

		public Employee Update(Employee employeeUpdate)
		{
			var employee = new Employee()
			{
				EmployeeName = employeeUpdate.EmployeeName,
				EmployeeAddress = employeeUpdate.EmployeeAddress,
				EmployeeAge = employeeUpdate.EmployeeAge,
				EmployeeDescription = employeeUpdate.EmployeeDescription			

			};
			_Context.Update(employeeUpdate);
			_Context.SaveChanges();
			return employeeUpdate;
		}
	}
}
