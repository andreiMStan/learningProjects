using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
				public class EmployeeService
								
				{
								private readonly IEmployeeRepository _repo;
								private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repo, IMapper mapper)
        {
												_repo = repo;
												_mapper = mapper;
        }

								public async Task<EmployeeDto> GetEmployeeById(int id) {
										

												// get the query from EmployeeRepository 
												var query = _repo.GetEmployeeById(id);
												//expose to dto the query and materialize 
									 return await _mapper.ProjectTo<EmployeeDto>(query).FirstOrDefaultAsync();
												// firstordefault are owner by ef core 
												// to list the same
										
								}

								public async Task<List<EmployeeDto>> GetEmployees()
								{
												var query = _repo.GetEmployees();
							return	await _mapper.ProjectTo<EmployeeDto>(query).ToListAsync();
								}
    }
}
