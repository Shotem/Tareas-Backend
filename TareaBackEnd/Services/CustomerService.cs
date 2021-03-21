using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaBackEnd.Models;

namespace TareaBackEnd.Services {
	
	public class CustomerService : BaseService {
		
		private IQueryable<Customer> getFromDB() {
			return dbContext.Customers;
		}

		public List<Customer> getAll() {
			return getFromDB().ToList();
		}

		public Customer getByID(string id) {
			var customer = getFromDB().Where(w => w.CustomerId == id).FirstOrDefault();
			if (customer == null) throw new Exception($"There's no customer with id {id}");

			return customer;
		}

		public void deleteByID(string id) {
			try {
				dbContext.Customers.Remove(getByID(id));
				dbContext.SaveChanges();
			} catch (Exception except) {
				Console.WriteLine($"Could not remove customer:\n{except.Message}");
				throw new Exception("Could not remove customer");
			}
		}

		public void insert( Customer customer ) {
			try {
				dbContext.Customers.Add(customer);
				dbContext.SaveChanges();
			} catch (Exception except) {
				Console.WriteLine($"Could not insert customer:\n{except.Message}");
				throw new Exception("Could not insert customer");
			}
			
		}
	}
}
