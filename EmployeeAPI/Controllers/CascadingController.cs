using EmployeeAPI.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/CascadingDropdown")]
    [ApiController]
    public class CascadingController(ICascadingLogic cascading) : ControllerBase
    {
        [Route("GetCountries")]
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var country = await cascading.BindCountry();

                return Ok(country);
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [Route("GetStates")]
        [HttpGet]
        public async Task<IActionResult> GetStates(int st)
        {
            try
            {
                var state = await cascading.BindState(st);

                return Ok(state);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [Route("GetCities")]
        [HttpGet]
        public async Task<IActionResult> GetCities(int ct)
        {
            try
            {
                var City = await cascading.BindCity(ct);

                return Ok(City);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }


    }
}
