using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaBackEnd.Models;
using TareaBackEnd.Services;

namespace TareaBackEnd.Controllers {
	[Route("api/[controller]")]
	[ApiController]

	public class EmployeeController : Controller {
		
		private EmployeeService employeeService = new EmployeeService();
		
		[HttpGet]
		public List<Employee> getEmployees() {
			return employeeService.getAll().Select( s => new Employee { 
				EmployeeId = s.EmployeeId,
				FirstName = s.FirstName,
				LastName = s.LastName
			} ).ToList();
		}

		[HttpGet("{id}")]
		public Employee getEmployeeByID(int id) {
			return employeeService.getByID(id);
		}

		[HttpPost]
		public void insertEmployee() {
			var employee = new Employee { };
			employeeService.insert(employee);
		}

		[HttpDelete("{id}")]
		public void deleteEmployeeByID(int id) {
			employeeService.deleteByID(id);
		}
	}
}
