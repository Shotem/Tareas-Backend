using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaBackEnd.Models;

namespace TareaBackEnd.Services {
	
	public class BaseService {
		protected NorthwindContext dbContext = new NorthwindContext();
	}
}
