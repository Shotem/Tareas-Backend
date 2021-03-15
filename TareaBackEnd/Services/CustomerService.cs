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
			return getFromDB().Where(w => w.CustomerId == id).FirstOrDefault();
		}

		public void deleteByID(string id) {
			dbContext.Customers.Remove(getByID(id));
			dbContext.SaveChanges();
		}

		public void insert( Customer c ) {
			dbContext.Customers.Add(c);
			dbContext.SaveChanges();
		}
	}
}
