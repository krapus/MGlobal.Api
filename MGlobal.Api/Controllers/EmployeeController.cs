using MGlobal.Core.Domain.Contracts;
using MGlobal.Core.Domain.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGlobal.Api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    [EnableCors("AllowOrigin")]    
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager _employeeManager)
        {
            this._employeeManager = _employeeManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                IEnumerable<EmployeeDTO> employees = await _employeeManager.GetEmployees();
                return (employees.Count() == 0) ? NoContent() : (IActionResult)Ok(employees);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                EmployeeDTO employee = await _employeeManager.GetEmployeeById(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
