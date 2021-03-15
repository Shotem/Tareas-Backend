using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaBackEnd.Models;

namespace TareaBackEnd.Services {
	public class EmployeeService : BaseService {
		private IQueryable<Employee> getFromDB() {
			return dbContext.Employees;
		}

		public List<Employee> getAll() {
			return getFromDB().ToList();
		}

		public Employee getByID(int id) {
			return getFromDB().Where(w => w.EmployeeId == id).FirstOrDefault();
		}

		public void deleteByID(int id) {
			dbContext.Employees.Remove(getByID(id));
			dbContext.SaveChanges();
		}

		public void insert(Employee c) {
			dbContext.Employees.Add(c);
			dbContext.SaveChanges();
		}

	}
}
