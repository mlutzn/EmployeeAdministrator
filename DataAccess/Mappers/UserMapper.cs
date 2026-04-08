using DataAccess.Dao;
using DTO;
using System.Data;

namespace DataAccess.Mapper
{
    public class UserMapper
    {
        public SqlOperation GetByEmailStatement(string email)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "sp_ValidateUser";
            operation.AddVarcharParam("Email", email);
            return operation;
        }
    }
}