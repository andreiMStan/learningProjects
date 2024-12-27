using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
				public class EmployeeRepository: IEmployeeRepository
				{
								private readonly AppDbContext _ctx;

        public EmployeeRepository(AppDbContext ctx)
        {
												_ctx = ctx;
								}

								public IQueryable<Employee> GetEmployeeById(int id)
								{
												return _ctx.Employees
																.Include(emp => emp.Address)
																.Where(emp => emp.Id == id)
																;
								}
								// this is a filter , It is a query , we don't materialize it 
								public IQueryable<Employee> GetEmployees()
								{
												return _ctx.Employees
																.Include(emp => emp.Address)
																.OrderBy(emp => emp.Id)
																.Skip(10)
																.Take(10)
																;
								}
    }
}
