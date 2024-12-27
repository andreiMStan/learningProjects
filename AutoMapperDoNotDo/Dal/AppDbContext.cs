using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
				public class AppDbContext:DbContext
				{
        public AppDbContext(DbContextOptions opt):base(opt)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }

								protected override void OnModelCreating(ModelBuilder builder)
								{
								//			base.OnModelCreating(modelBuilder);
								builder.Entity<Employee>().HasData(GetEmployees());
	builder.Entity<Address>().HasData(GetAddresses());
								}

								private List<Employee> GetEmployees()
								{
												return Enumerable.Range(1, 100)
																.Select(index => new Employee
																{
																				Name = $"Employee{index}",
																				Department = $"Department{index}",
																				Id = index,
																				JobRole = "Software Engineer",
																				RegistrationId = index

																}).ToList();
								}

								private List<Address> GetAddresses()
								{
												return Enumerable.Range(1, 100)
																.Select(index => new Address
																{
																				Id = index,
																				EmployeeId = index,
																				City = "Timisoara",
																				Street = $"Street {index}",
																				Number = index,
																				Country = "Romania"

																}).ToList();
								}
				}
}
