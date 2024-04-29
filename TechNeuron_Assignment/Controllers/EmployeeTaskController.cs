using Microsoft.AspNetCore.Mvc;
using TechNeuron_Assignment.Models;
using TechNeuron_Assignment.Repositories;

namespace TechNeuron_Assignment.Controllers
{
	public class EmployeeTaskController : Controller
	{
		private readonly IEmployeeTaskRepository _employeeTaskRepository;

        public EmployeeTaskController(IEmployeeTaskRepository employeeTaskRepository)
        {
            _employeeTaskRepository = employeeTaskRepository;
        }
        public IActionResult Index()
		{
			var employee = _employeeTaskRepository.GetAll();
			return View(employee);
		}

		//Insert Data into Database
		[HttpPost]
		public IActionResult Create(EmployeeTask employeetask)
		{
			if (!ModelState.IsValid)
			{
				return View(employeetask);
			}
			EmployeeTask newemployee = _employeeTaskRepository.Add(employeetask);
			return RedirectToAction("Index", "EmployeeTask");
		}

		//Fetch Data from Database
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		//Fetch Data from Database for Updating
		[HttpGet]
		public IActionResult Update(int id)
		{
			EmployeeTask employeeTask = _employeeTaskRepository.GetEmployeeTask(id);
			return View(employeeTask);
		}

		//Update Data from Database
		[HttpPost]
		public IActionResult Update(EmployeeTask employeeTaskUpdate)
		{
            if (!ModelState.IsValid)
            {
                return View(employeeTaskUpdate);
            }

            EmployeeTask employeeTask = _employeeTaskRepository.GetEmployeeTask(employeeTaskUpdate.TaskID);
			employeeTask.TaskName = employeeTaskUpdate.TaskName;
			employeeTask.TaskDescription = employeeTaskUpdate.TaskDescription;
            EmployeeTask updatedTutorial = _employeeTaskRepository.Update(employeeTask);
            return RedirectToAction("Index", "EmployeeTask");
		}

		//Delete Data from Database
		[HttpPost]
		public IActionResult Delete(EmployeeTask employeeTaskDelete)
		{
			EmployeeTask employeeTask = _employeeTaskRepository.GetEmployeeTask(employeeTaskDelete.TaskID);
			employeeTaskDelete.TaskName = employeeTask.TaskName;
			employeeTaskDelete.TaskDescription = employeeTask.TaskDescription;			
			EmployeeTask deleteemployeetask1 = _employeeTaskRepository.Delete(employeeTaskDelete.TaskID);
			return RedirectToAction("Index", "EmployeeTask");
		}

		//Fetch Data from Database for Deleting
		[HttpGet]
		public IActionResult Delete(int id)
		{
			EmployeeTask employeeTask = _employeeTaskRepository.GetEmployeeTask(id);
			return View(employeeTask);
		}
	}
}
