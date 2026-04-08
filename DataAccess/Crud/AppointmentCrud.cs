using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;

namespace DataAccess.Crud
{
    public class AppointmentCrud : CrudFactory
    {
        AppointmentMapper _mapper;

        public AppointmentCrud()
        {
            _mapper = new AppointmentMapper();
            _sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass dto)
        {
            var operation = _mapper.GetCreateStatement(dto);
            _sqlDao.ExecuteProcedure(operation);
        }

        public override void Delete(BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var operation = _mapper.GetRetrieveAllStatement();
            var results = _sqlDao.ExecuteProcedureWithQuery(operation);

            var resultList = new List<T>();
            if (results.Count > 0)
            {
                var dtoList = _mapper.BuildObjects(results);
                foreach (var item in dtoList)
                {
                    resultList.Add((T)Convert.ChangeType(item, typeof(T)));
                }
            }
            return resultList;
        }

        public override List<T> RetrieveById<T>(int pId)
        {
            var operation = _mapper.GetRetrieveByIdStatement(pId);
            var results = _sqlDao.ExecuteProcedureWithQuery(operation);

            var resultList = new List<T>();
            if (results.Count > 0)
            {
                var dtoList = _mapper.BuildObjects(results);
                foreach (var item in dtoList)
                {
                    resultList.Add((T)Convert.ChangeType(item, typeof(T)));
                }
            }
            return resultList;
        }

        public override List<T> RetrieveAllByPatientId<T>(int patientId)
        {
            var operation = _mapper.GetRetrieveByPatientIdStatement(patientId);
            var results = _sqlDao.ExecuteProcedureWithQuery(operation);

            var resultList = new List<T>();
            if (results.Count > 0)
            {
                var dtoList = _mapper.BuildObjects(results);
                foreach (var item in dtoList)
                {
                    resultList.Add((T)Convert.ChangeType(item, typeof(T)));
                }
            }
            return resultList;
        }

        public override void Update(BaseClass dto)
        {
            throw new NotImplementedException();
        }
    }
}