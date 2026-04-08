using DataAccess.Dao;
using DTO;

namespace DataAccess.Crud
{
    public abstract class CrudFactory
    {
        protected SqlDao _sqlDao;

        public abstract void Create(BaseClass dto);
        public abstract void Update(BaseClass dto);
        public abstract void Delete(BaseClass dto);
        public abstract List<T> RetrieveAll<T>();
        public abstract List<T> RetrieveById<T>(int pId);
        public abstract List<T> RetrieveAllByPatientId<T>(int patientId);
    }
}
