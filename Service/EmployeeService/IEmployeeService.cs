using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos.Employee;

namespace WebApi.Service.EmployeeService
{
    public interface IEmployeeService
    {
        public Task<ServiceReponse<GetEmployeeDto>> GetEmployee();

        public Task<ServiceReponse<List<GetEmployeeDto>>> GetAllEmployee();

        public Task<ServiceReponse<List<GetEmployeeDto>>> AddEmployee(AddEmployeeDto employee);

        public Task<ServiceReponse<GetEmployeeDto>> GetEmployeebyID(int id);

        public Task<ServiceReponse<GetEmployeeDto>> UpdateEmployee(UpdateEmployeeDto employee);
        
        public Task<ServiceReponse<List<GetEmployeeDto>>> DeleteEmployee(int id);
        
    }
}