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
			var employee = getFromDB().Where(w => w.EmployeeId == id).FirstOrDefault();
			if (employee == null) throw new Exception($"There's no employee with id {id}");
			
			return employee;
		}

		public void deleteByID(int id) {
			try {
				dbContext.Employees.Remove(getByID(id));
				dbContext.SaveChanges();
			} catch (Exception except) {
				Console.WriteLine($"Could not remove employee:\n{except.Message}");
				throw new Exception("Could not remove employee");
			}
		}

		public void insert(Employee employee) {
			try {
				dbContext.Employees.Add(employee);
				dbContext.SaveChanges();
			} catch (Exception except) {
				Console.WriteLine($"Could not insert employee:\n{except.Message}");
				throw new Exception("Could not insert employee");
			}
		}

	}
}
