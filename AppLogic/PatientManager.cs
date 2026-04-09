using DataAccess.Crud;
using DTO;

namespace AppLogic
{
    public interface IPatientManager
    {
        List<Patient> GetAllPatient();
        string GetPatientByDoctor(int pIdDoctor);
        string GetPatient();
    }
    public class PatientManager : IPatientManager
    {
        public List<Patient> GetAllPatient()
        {
            var crud = new PatientCrud();
            return crud.RetrieveAll<Patient>();
        }
        public string GetPatientByDoctor(int pIdDoctor)
        {
            return "Datos del paciente by doctor " + pIdDoctor;
        }
        public string GetPatient()
        {
            return "Datos del paciente";
        }
    }
}
