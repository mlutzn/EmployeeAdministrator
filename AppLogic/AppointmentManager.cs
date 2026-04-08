using DataAccess.Crud;
using DTO;

namespace AppLogic
{
    public interface IAppointmentManager
    {
        string CreateAppointment(Appointment appointment);
        List<Appointment> GetAppointmentByPatientId(int patientId);
        List<Appointment> GetAllAppointment();
    }

    public class AppointmentManager : IAppointmentManager
    {
        public string CreateAppointment(Appointment appointment)
        {
            var appointmentCrud = new AppointmentCrud();
            appointmentCrud.Create(appointment);
            return "Cita registrada de manera correcta";
        }

        public List<Appointment> GetAppointmentByPatientId(int patientId)
        {
            var appointmentCrud = new AppointmentCrud();
            return appointmentCrud.RetrieveAllByPatientId<Appointment>(patientId);
        }

        public List<Appointment> GetAllAppointment()
        {
            var crud = new AppointmentCrud();
            return crud.RetrieveAll<Appointment>();
        }
    }
}