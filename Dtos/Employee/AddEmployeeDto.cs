using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos.Employee
{
    public class AddEmployeeDto
    {        
        public string empName { get; set; } ="Shri";

        public int empSalary { get; set; } =1000;

        public EmployeeType employeeType { get; set; } =EmployeeType.Permanant;
    }
}