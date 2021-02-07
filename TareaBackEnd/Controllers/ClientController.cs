using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TareaBackEnd.Models;

namespace TareaBackEnd.Controllers {
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ClientController : Controller {
		private NorthwindContext context = new NorthwindContext();

		[HttpGet]
		private IQueryable<Customer> getCustomersFromDB() {
			return context.Customers.AsQueryable();
		}

		public List<Customer> getCustomers() {
			return getCustomersFromDB().ToList();
		}
	}
}
