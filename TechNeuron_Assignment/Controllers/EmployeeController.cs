using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechNeuron_Assignment.Models;
using TechNeuron_Assignment.Repositories;

namespace TechNeuron_Assignment.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
		{
			var employee = _employeeRepository.GetAll();
			return View(employee);
		}

		//Insert Data into Database
		[HttpPost]
		public IActionResult Create(Employee employee)
		{
			if (!ModelState.IsValid)
			{
				return View(employee);
			}
			Employee newemployee = _employeeRepository.Add(employee);
			return RedirectToAction("Index", "Employee");
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
			Employee employee = _employeeRepository.GetEmployee(id);
			return View(employee);
		}

		//Update Data from Database
		[HttpPost]      
        public IActionResult Update(Employee employeeUpdate)
		{
            if (!ModelState.IsValid)
            {
                return View(employeeUpdate);
            }

            Employee employee = _employeeRepository.GetEmployee(employeeUpdate.EmployeeID);
			employee.EmployeeName = employeeUpdate.EmployeeName;
			employee.EmployeeDescription = employeeUpdate.EmployeeDescription;
			employee.EmployeeAddress = employeeUpdate.EmployeeAddress;
			employee.EmployeeAge = employeeUpdate.EmployeeAge;
			Employee updatedTutorial = _employeeRepository.Update(employee);
            return RedirectToAction("Index", "Employee");
		}

		//Delete Data from Database
		[HttpPost]
		public IActionResult Delete(Employee employeeDelete)
		{
			Employee employee = _employeeRepository.GetEmployee(employeeDelete.EmployeeID);
			employeeDelete.EmployeeName = employee.EmployeeName;
			employeeDelete.EmployeeDescription = employee.EmployeeDescription;
			employeeDelete.EmployeeAddress = employee.EmployeeAddress;
			employeeDelete.EmployeeAge = employee.EmployeeAge;			
			Employee deleteemployee1 = _employeeRepository.Delete(employeeDelete.EmployeeID);
			return RedirectToAction("Index", "Employee");
		}

		//Fetch Data from Database for Deleting
		[HttpGet]
		public IActionResult Delete(int id)
		{
			Employee employee = _employeeRepository.GetEmployee(id);
			return View(employee);
		}
	}
}
