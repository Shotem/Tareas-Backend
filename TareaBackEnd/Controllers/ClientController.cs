using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TareaBackEnd.Models;
using TareaBackEnd.Services;

namespace TareaBackEnd.Controllers {
	[Route("api/[controller]")]
	[ApiController]

	public class ClientController : Controller {

		private CustomerService customer_service = new CustomerService();

		[HttpGet]
		public List<Customer> getCustomers() {
			return customer_service.getAll();
		}

		[HttpGet("{id}")]
		public Customer getCustomersByID(string id) {
			return customer_service.getByID( id );
		}

		[HttpPost]
		public void insertCustomer() {
			var customer = new Customer { };
			customer_service.insert( customer );
		}

		[HttpDelete("{id}")]
		public void deleteCustomerByID(string id) {
			customer_service.deleteByID( id );
		}



	}
}
