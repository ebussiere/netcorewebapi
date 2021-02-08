using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netcorewebapi.Data.Models;
using netcorewebapi.Data.Services;
using netcorewebapi.Data.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace netcorewebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public EmployeesService _employeesService;

        public EmployeesController(EmployeesService employeesService)
        {
            _employeesService = employeesService;
        }


        // GET: api/<EmployeesController>
        [HttpGet]
        public IActionResult Get()
        {
           var allBooks= _employeesService.GetEmployees();
           return Ok(allBooks);
        }


        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var oneBook= _employeesService.GetEmployeeById(id);
            return Ok(oneBook);
        }

        // POST api/<EmployeesController>
        [HttpPost]
         public IActionResult AddEmployee([FromBody] EmployeeVM employee)
        {
            _employeesService.AddEmployee(employee);
            return Ok();
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateEmployeeById(int id, [FromBody] EmployeeVM employee)
        {
            var updatedEmployee = _employeesService.UpdateEmployeeById(id, employee);
            return Ok(updatedEmployee);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]

        public IActionResult DeleteEmployeeById(int id)
        {
            _employeesService.DeleteEmployeeById(id);
            return Ok();
        }
    }
}
