using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TareaBackEnd.Models;
using TareaBackEnd.Services;

namespace TareaBackEnd.Controllers {
	[Route("api/[controller]")]
	[ApiController]

	public class CustomerController : Controller {

		private CustomerService customer_service = new CustomerService();

		[HttpGet]
		public IActionResult getCustomers() {
			try { 
				return Ok(customer_service.getAll());
			} catch (Exception exept) {
				return StatusCode(StatusCodes.Status500InternalServerError, exept.Message);
			}
		}

		[HttpGet("{id}")]
		public IActionResult getCustomersByID(string id) {
			try {
				return Ok(customer_service.getByID(id));
			} catch (Exception except) {
				return StatusCode(StatusCodes.Status500InternalServerError, except.Message);
			}
		}

		[HttpPost]
		public IActionResult insertCustomer() {
			try {
				var customer = new Customer { };
				customer_service.insert(customer);
				return Ok();
			} catch (Exception except) {
				return StatusCode(StatusCodes.Status500InternalServerError, except.Message);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult deleteCustomerByID(string id) {
			try {
				customer_service.deleteByID(id);
				return Ok();
			} catch (Exception except) {
				return StatusCode(StatusCodes.Status500InternalServerError, except.Message);
			}
		}
	}
}
