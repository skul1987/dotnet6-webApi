using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class Employee
    {
        [Key] 
        public int empId { get; set; }
        
        public string empName { get; set; } ="Shri";

        public int empSalary { get; set; } =1000;

        public EmployeeType employeeType { get; set; } =EmployeeType.Permanant;

        public User? updatedbyUser { get; set; }
    }
}