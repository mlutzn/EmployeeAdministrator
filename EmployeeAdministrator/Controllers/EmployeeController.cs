using AppLogic;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("DemoPolicy")]
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
        public async Task<ApiResponse> GetAllEmployees()
        {
            var response = new ApiResponse();
            try
            {
                var result = await _employeeconector.RetrieveAllEmployees();
                response.Data = result;
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = $"Error interno: {ex.Message}";
            }
            return response;
        }

        [HttpGet("GetAllEmployeesRestSharp")]
        public async Task<ApiResponse> GetAllEmployeesRestSharp()
        {
            var response = new ApiResponse();
            try
            {
                var result = await _employeeconector.GetAllEmployeesRestSharp();
                response.Data = result;
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = $"Error interno: {ex.Message}";
            }
            return response;
        }

        [HttpGet("GetAllEmployeesFlurl")]
        public async Task<ApiResponse> GetAllEmployeesFlurl()
        {
            var response = new ApiResponse();
            try
            {
                var result = await _employeeconector.GetAllEmployeesFlurl();
                response.Data = result;
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = $"Error interno: {ex.Message}";
            }
            return response;
        }

        [HttpGet("GetEmployeeManager")]
        public async Task<ApiResponse> GetEmployeeById(int id)
        {
            var response = new ApiResponse();
            try
            {
                var result = await _employeeconector.GetEmployeeById(id);
                if (result == null)
                {
                    response.Result = "error";
                    response.Message = $"Empleado con ID {id} no encontrado";
                }
                else
                {
                    response.Data = result;
                    response.Result = "ok";
                }
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = $"Error interno: {ex.Message}";
            }
            return response;
        }

        [HttpGet("GetEmployeeManager/{employeeId}")]
        public async Task<ApiResponse> GetEmployeeManager(int employeeId)
        {
            var response = new ApiResponse();
            try
            {
                var result = await _employeeconector.GetEmployeeManager(employeeId);
                if (result == null)
                {
                    response.Result = "error";
                    response.Message = $"No se encontró manager para el empleado con ID {employeeId}";
                }
                else
                {
                    response.Data = result;
                    response.Result = "ok";
                }
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = $"Error interno: {ex.Message}";
            }
            return response;
        }

        [HttpGet("GetOldestEmployee")]
        public async Task<ApiResponse> GetOldestEmployee()
        {
            var response = new ApiResponse();
            try
            {
                var result = await _employeeconector.GetOldestEmployee();
                response.Data = result;
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = $"Error interno: {ex.Message}";
            }
            return response;
        }

        [HttpGet("GetNewestEmployee")]
        public async Task<ApiResponse> GetNewestEmployee()
        {
            var response = new ApiResponse();
            try
            {
                var result = await _employeeconector.GetNewestEmployee();
                response.Data = result;
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = $"Error interno: {ex.Message}";
            }
            return response;
        }

        [HttpGet("GetEmployeesWithMoreThan/{years}")]
        public async Task<ApiResponse> GetEmployeesWithMoreThan(int years)
        {
            var response = new ApiResponse();
            try
            {
                if (years < 0)
                {
                    response.Result = "error";
                    response.Message = "Los años no pueden ser negativos";
                }
                else
                {
                    var result = await _employeeconector.GetEmployeesWithMoreThan(years);
                    response.Data = result;
                    response.Result = "ok";
                }
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = $"Error interno: {ex.Message}";
            }
            return response;
        }

        [HttpGet("GetEmployeesWithLessThan/{years}")]
        public async Task<ApiResponse> GetEmployeesWithLessThan(int years)
        {
            var response = new ApiResponse();
            try
            {
                if (years < 0)
                {
                    response.Result = "error";
                    response.Message = "Los años no pueden ser negativos";
                }
                else
                {
                    var result = await _employeeconector.GetEmployeesWithLessThan(years);
                    response.Data = result;
                    response.Result = "ok";
                }
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = $"Error interno: {ex.Message}";
            }
            return response;
        }
    }
}