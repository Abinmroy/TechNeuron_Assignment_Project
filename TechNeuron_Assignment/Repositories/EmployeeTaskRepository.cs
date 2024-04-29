using TechNeuron_Assignment.Data;
using TechNeuron_Assignment.Models;

namespace TechNeuron_Assignment.Repositories
{
	public class EmployeeTaskRepository : IEmployeeTaskRepository
	{
		private readonly ApplicationDbContext _Context;
        public EmployeeTaskRepository(ApplicationDbContext context)
        {
            _Context = context;
        }
        public EmployeeTask Add(EmployeeTask employeeTask)
		{
			_Context.Tasks.Add(employeeTask);
			_Context.SaveChanges();
			return employeeTask;
		}

		public EmployeeTask Delete(int id)
		{
			EmployeeTask employeeTask = _Context.Tasks.Find(id);
			if (employeeTask != null)
			{
				_Context.Tasks.Remove(employeeTask);
				_Context.SaveChanges();
			}
			return employeeTask;
		}

		public IEnumerable<EmployeeTask> GetAll()
		{
			return _Context.Tasks;
		}

		public EmployeeTask GetEmployeeTask(int id)
		{
			return _Context.Tasks.Find(id);
		}

		public EmployeeTask Update(EmployeeTask employeeTaskUpdate)
		{
			var employeetask = new EmployeeTask()
			{
				TaskName = employeeTaskUpdate.TaskName,
				TaskDescription = employeeTaskUpdate.TaskDescription
			};
			_Context.Update(employeeTaskUpdate);
			_Context.SaveChanges();
			return employeeTaskUpdate;
		}
	}
}
