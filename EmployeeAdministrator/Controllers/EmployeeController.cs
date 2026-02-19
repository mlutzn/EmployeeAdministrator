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

        public EmployeeController(IEmployeeConnector employeeconector)
        {
            _employeeconector = employeeconector;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            try
            {
                var result = await _employeeconector.RetrieveAllEmployees();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        [HttpGet("GetAllEmployeesRestSharp")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployeesRestSharp()
        {
            try
            {
                var result = await _employeeconector.GetAllEmployeesRestSharp();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpGet("GetAllEmployeesFlurl")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployeesFlurl()
        {
            try
            {
                var result = await _employeeconector.GetAllEmployeesFlurl();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpGet("GetEmployeeManager")]
        public async Task<ActionResult<Employee?>> GetEmployeeById(int id)
        {
            try
            {
                var result = await _employeeconector.GetEmployeeById(id);
                if (result == null)
                    return NotFound($"Empleado con ID {id} no encontrado");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpGet("GetEmployeeManager/{employeeId}")]
        public async Task<ActionResult<Employee?>> GetEmployeeManager(int employeeId)
        {
            try
            {
                var result = await _employeeconector.GetEmployeeManager(employeeId);
                if (result == null)
                    return NotFound($"No se encontró manager para el empleado con ID {employeeId}");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpGet("GetOldestEmployee")]
        public async Task<ActionResult<List<Employee>>> GetOldestEmployee()
        {
            try
            {
                var result = await _employeeconector.GetOldestEmployee();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpGet("GetNewestEmployee")]
        public async Task<ActionResult<List<Employee>>> GetNewestEmployee()
        {
            try
            {
                var result = await _employeeconector.GetNewestEmployee();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpGet("GetEmployeesWithMoreThan/{years}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeesWithMoreThan(int years)
        {
            try
            {
                if (years < 0)
                    return BadRequest("Los años no pueden ser negativos");

                var result = await _employeeconector.GetEmployeesWithMoreThan(years);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpGet("GetEmployeesWithLessThan/{years}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeesWithLessThan(int years)
        {
            try
            {
                if (years < 0)
                    return BadRequest("Los años no pueden ser negativos");

                var result = await _employeeconector.GetEmployeesWithLessThan(years);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}