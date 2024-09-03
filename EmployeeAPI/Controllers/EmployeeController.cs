using EmployeeAPI.Data.Models;
using EmployeeAPI.Services.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(ICRUDLogic cRUDLogic) : ControllerBase
    {
        [Route("EmployeeList")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var result = await cRUDLogic.GetEmpData();
                return Ok(result);

            }
            catch
            {
                return StatusCode(400);
            }

        }

        [Route("NewEmployee")]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
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

        [Route("EditEmployee")]
        [HttpPut]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditEmployee(EmpData data,int e)
        {
            try
            {
                var result = await cRUDLogic.UpdateEmpData(data,e);
                return Ok(result);
            }
            catch
            {
                return StatusCode(400);
            }

        }

        [Route("RemoveEmployee")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            try
            {
                var result = await cRUDLogic.DeleteEmpData(Id);
                return Ok(result);

            }
            catch
            {
                return StatusCode(400);
            }

        }


    }
}
