using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Service.EmployeeService;
using WebApi.Dtos.Employee;

namespace WebApi.Controllers
{
    [ApiController]  
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employervice;
        public EmployeeController(IEmployeeService employeeService)
        {
         _employervice =   employeeService;
        }       

        [HttpGet(Name = "GetEmployee")]
        public async Task<ActionResult<ServiceReponse<GetEmployeeDto>>> get()
        {         
         return Ok(await _employervice.GetEmployee());
            
        }
       
        [HttpGet("GetEmployeeList")]
        public async Task<ActionResult<ServiceReponse<List<GetEmployeeDto>>>> getEmployeeList()
        {         
         return Ok(await _employervice.GetAllEmployee());
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceReponse<GetEmployeeDto>>> getEmployeeById(int id)
        {         
         return Ok(await _employervice.GetEmployeebyID(id));
            
        }

        [HttpPost]
        public async Task<ActionResult<ServiceReponse<List<GetEmployeeDto>>>> addEmployee(AddEmployeeDto emp)
        {     
         
         return Ok(await _employervice.AddEmployee(emp));
            
        }

        [HttpPut]
        public async Task<ActionResult<ServiceReponse<GetEmployeeDto>>> updateEmployee(UpdateEmployeeDto emp)
        {     
         
         var response =await _employervice.UpdateEmployee(emp);
         if(response.Data == null)
         {
            return NotFound(response);
         }
         return Ok(response);
            
        }

         [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceReponse<List<GetEmployeeDto>>>> deleteEmployee(int id)
        {     
         
         var response =await _employervice.DeleteEmployee(id);
         if(response.Data == null)
         {
            return NotFound(response);
         }
         return Ok(response);
            
        }

    }
}