﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
				public interface IEmployeeRepository
				{
								IQueryable<Employee> GetEmployeeById(int id);

								IQueryable<Employee> GetEmployees();
				}
}