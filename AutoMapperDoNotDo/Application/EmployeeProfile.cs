using AutoMapper;
using Domain;

namespace Application
{
				public class EmployeeProfile:Profile
				{
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            
        }
    }
}
