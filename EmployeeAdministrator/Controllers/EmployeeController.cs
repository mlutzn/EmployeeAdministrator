using AppLogic;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRHConnector _rhConnector;

        public EmployeeController(IRHConnector rhConnector)
        {
            _rhConnector = rhConnector;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _rhConnector.RetrieveAllEmployees();
        }

        [HttpGet("GetAllSpecialties")]
        public async Task<List<string>> GetAllSpecialties()
        {
            return await _rhConnector.RetrieveAllSpecialties();
        }
    }
}
