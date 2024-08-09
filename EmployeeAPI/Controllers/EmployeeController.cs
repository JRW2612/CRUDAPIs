using EmployeeAPI.Data.Models;
using EmployeeAPI.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(ICRUDLogic cRUDLogic) : ControllerBase
    {

        [Route("NewEmployee")]
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmpData data)
        {
            try 
            {
                var result = await cRUDLogic.AddEmpData(data);
                return Ok(result);
            }
            catch 
            {
                return StatusCode(400);
            }

        }
    }
}
