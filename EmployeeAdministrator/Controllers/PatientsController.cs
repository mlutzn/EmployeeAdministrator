using AppLogic;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("DemoPolicy")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientManager _patientManager;

        public PatientsController(IPatientManager ipmanager) 
        {
            _patientManager = ipmanager;
        }


        [HttpGet("Get")]
        public ApiResponse GetPatient()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = _patientManager.GetPatient();
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }
            return response;
        }
        [HttpGet("GetAll")]
        public ApiResponse GetAllPatient()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = _patientManager.GetAllPatient();
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }
            return response;
        }
        [HttpGet("GetByDoctor")]
        public ApiResponse GetPatientByDoctor(int pIdDoctor)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = _patientManager.GetPatientByDoctor(pIdDoctor);
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
