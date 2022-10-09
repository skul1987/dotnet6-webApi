using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Dtos.Employee;

namespace WebApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee,GetEmployeeDto>();
            CreateMap<AddEmployeeDto,Employee>();
            CreateMap<UpdateEmployeeDto,Employee>();
            
        }
        
    }
}