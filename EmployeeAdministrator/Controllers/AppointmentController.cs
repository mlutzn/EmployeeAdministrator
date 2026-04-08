using AppLogic;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [EnableCors("DemoPolicy")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentManager _appointmentManager;

        public AppointmentController(IAppointmentManager appManager)
        {
            _appointmentManager = appManager;
        }

        [HttpPost("CrearCita")]
        public ApiResponse CreateAppointment(Appointment dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = _appointmentManager.CreateAppointment(dto);
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet("GetAppointmentByPatientId")]
        public IActionResult GetAppointmentByPatientId(int patientId)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userRole != "ADMIN")
            {
                if (userIdClaim == null || int.Parse(userIdClaim) != patientId)
                {
                    return Unauthorized("Accion no permitida, valores ingresados inconcientes.");
                }
            }

            var response = new ApiResponse();
            try
            {
                response.Data = _appointmentManager.GetAppointmentByPatientId(patientId);
                response.Result = "ok";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("GetAll")]
        public List<Appointment> GetAllAppointment()
        {
            return _appointmentManager.GetAllAppointment();
        }
    }
}