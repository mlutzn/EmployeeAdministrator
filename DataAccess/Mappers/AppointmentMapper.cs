using DataAccess.Dao;
using DataAccess.Mappers.Interfaces;
using DTO;

namespace DataAccess.Mappers
{
    public class AppointmentMapper : IObjectMapper, ICrudStatements
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var Cita = new Appointment();
            Cita.Id = int.Parse(row[key: "Id"].ToString());
            Cita.PatientId = int.Parse(row[key: "PatientId"].ToString());
            Cita.Title = row[key: "Title"].ToString();
            Cita.Date = row[key: "Date"].ToString();
            Cita.Speciality = row[key: "Speciality"].ToString();
            return Cita;
            var appointment = new Appointment();
            appointment.Id = int.Parse(row["Id"].ToString());
            appointment.PatientId = int.Parse(row["PatientId"].ToString());
            appointment.Title = row["Title"].ToString();
            appointment.Speciality = row["Speciality"].ToString();
            appointment.AppointmentDate = DateTime.Parse(row["Date"].ToString());
            return appointment; 
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> rows)
        {
            var results = new List<BaseClass>();
            foreach (var item in rows)
            {
                var row = BuildObject(item);
                results.Add(row);
            }

            return results;
        }

        public SqlOperation GetCreateStatement(BaseClass dto)
        {
            var appointment = (Appointment)dto;

            var operation = new SqlOperation();
            operation.ProcedureName = "SP_INSERT_APPOINTMENT"; // aca va el nombre del SP  creado en la BD

            operation.AddIntParam("patientid", appointment.PatientId);
            operation.AddDatetimeParam("date", appointment.AppointmentDate);
            operation.AddVarcharParam("title", appointment.Title);
            operation.AddVarcharParam("specialty", appointment.Speciality);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_GET_ALL_APPOINTMENTS";
            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int pId)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveByPatientIdStatement(int PatientId)
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_GET_APPOINTMENTS_BY_PATIENT_ID";
            operation.AddIntParam("patientId", PatientId);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllByPatientIdStatement(int patientId) 
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_GET_APPOINTMENTS_BY_PATIENT_ID";
            operation.AddIntParam("patientid", patientId);
            return operation;
        }
    }
}
