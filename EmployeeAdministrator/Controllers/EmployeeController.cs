using AppLogic;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeConnector _employeeconector;

        public EmployeeController(AppLogic.IEmployeeConnector employeeconector)
        {
            _employeeconector = employeeconector;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _employeeconector.RetrieveAllEmployees();
        }

        [HttpGet("GetAllSpecialties")]
        public async Task<List<string>> GetAllSpecialties()
        {
            return await _employeeconector.RetrieveAllSpecialties();
        }
    }
}
