using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos.Employee;
using AutoMapper;
using WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Service.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {              
        private static Employee emp = new Employee();
        private static List<Employee> empList =new List<Employee>{
            new Employee(),
            new Employee{ empId=5, empName="Meenal Kulkarni", empSalary=4990, employeeType=EmployeeType.Contract}
        };

        private readonly IMapper _mapper;
        private readonly EmployeeDataContext _dataContext;
        public EmployeeService(IMapper mapper,EmployeeDataContext dataContext)
        {
            _mapper =mapper;
            _dataContext =dataContext;
        }

        public async Task<ServiceReponse<List<GetEmployeeDto>>> AddEmployee(AddEmployeeDto employee)
        {
           var serviceReponse = new ServiceReponse<List<GetEmployeeDto>>();
           Employee newEmployee =_mapper.Map<Employee>(employee);
           _dataContext.Employees.Add(newEmployee);
           await _dataContext.SaveChangesAsync();
           serviceReponse.Data =await _dataContext.Employees.Select(c=> _mapper.Map<GetEmployeeDto>(c)).ToListAsync();
           return serviceReponse;
        }

        public async Task<ServiceReponse<GetEmployeeDto>> UpdateEmployee(UpdateEmployeeDto employee)
        {
            var serviceReponse = new ServiceReponse<GetEmployeeDto>();       
            try
            {
                    Employee tempemployee =  await _dataContext.Employees.FirstOrDefaultAsync(c=> c.empId == employee.empId); 
                   // tempemployee.employeeType =employee.employeeType;
                    tempemployee.empName =employee.empName;
                    tempemployee.empSalary =employee.empSalary;
                    await _dataContext.SaveChangesAsync();
                    serviceReponse.Data= _mapper.Map<GetEmployeeDto>(tempemployee);
            }
            catch(Exception ex)
            {
                    serviceReponse.Success =false;
                    serviceReponse.Message =ex.Message;
            }
            return serviceReponse;
          
        }

        public async Task<ServiceReponse<List<GetEmployeeDto>>> DeleteEmployee(int id)
        {
            var serviceReponse = new ServiceReponse<List<GetEmployeeDto>>();       
            try
            {
                Employee tempemployee = await _dataContext.Employees.FirstAsync(c=> c.empId == id); 
                _dataContext.Employees.Remove(tempemployee);   
                await _dataContext.SaveChangesAsync();                 
                serviceReponse.Data= await _dataContext.Employees.Select(c=>_mapper.Map<GetEmployeeDto>(c)).ToListAsync();
            }
            catch(Exception ex)
            {
                    serviceReponse.Success =false;
                    serviceReponse.Message =ex.Message;
            }
            return serviceReponse;          
        }

        public async Task<ServiceReponse<List<GetEmployeeDto>>> GetAllEmployee()
        {            
            var serviceReponse = new ServiceReponse<List<GetEmployeeDto>>();
            var dbEmployees = await _dataContext.Employees.ToListAsync();
            serviceReponse.Data = dbEmployees.Select(c=> _mapper.Map<GetEmployeeDto>(c)).ToList();
            return serviceReponse;          
        }

        public async Task<ServiceReponse<GetEmployeeDto>> GetEmployee()
        {
            return new ServiceReponse<GetEmployeeDto>{Data = _mapper.Map<GetEmployeeDto>(emp)} ;
        }

        public async Task<ServiceReponse<GetEmployeeDto>> GetEmployeebyID(int id)
        {
           var serviceReponse = new ServiceReponse<GetEmployeeDto>();        
           Employee dbEmployee = await _dataContext.Employees.FirstOrDefaultAsync(c=> c.empId ==id);
           serviceReponse.Data= _mapper.Map<GetEmployeeDto>(dbEmployee);
           return serviceReponse;
        }
    }
}