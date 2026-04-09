using DataAccess.Dao;
using DataAccess.Mapper;
using DTO;
using System.Data;

namespace DataAccess.Crud
{
    public class UserCrud : CrudFactory
    {
        private UserMapper _mapper;

        public UserCrud()
        {
            _mapper = new UserMapper();
            _sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveById<T>(int pId)
        {
            throw new NotImplementedException();
        }
        public override List<T> RetrieveAllByPatientId<T>(int patientId)
        {
            throw new NotImplementedException();
        }

        // Método específico para login
        public UserDto? GetByEmail(string email)
        {
            SqlOperation operation = _mapper.GetByEmailStatement(email);
            var results = _sqlDao.ExecuteProcedureWithQuery(operation);

            if (results == null || results.Count == 0)
                return null;

            var row = results[0];
            var user = new UserDto
            {
                Id = Convert.ToInt32(row["id"]),
                Email = row["email"].ToString(),
                PasswordHash = row["password_hash"].ToString(),
                Rol = row["rol"].ToString()
            };
            return user;
        }

    }
}