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
		public IActionResult getEmployees() {
			try {
				return Ok(employeeService.getAll());
			} catch (Exception except) {
				return StatusCode(StatusCodes.Status500InternalServerError, except.Message);
			}
			
		}

		[HttpGet("{id}")]
		public IActionResult getEmployeeByID(int id) {
			try {
				return Ok(employeeService.getByID(id));
			} catch (Exception exept) {
				return StatusCode(StatusCodes.Status500InternalServerError, exept.Message);
			}
		}

		[HttpPost]
		public IActionResult insertEmployee() {
			try {
				var employee = new Employee { };
				employeeService.insert(employee);
				return Ok();
			} catch (Exception except) {
				return StatusCode(StatusCodes.Status500InternalServerError, except.Message);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult deleteEmployeeByID(int id) {
			try {
				employeeService.deleteByID(id);
				return Ok();
			} catch (Exception except) {
				return StatusCode(StatusCodes.Status500InternalServerError, except.Message);
			}
		}
	}
}
