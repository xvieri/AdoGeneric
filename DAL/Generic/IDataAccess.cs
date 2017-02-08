using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Generic
{
    public interface IDataAccess
    {
        SqlDataReader GetReader(string sql, List<SqlParameter> listParam= null );
        object GetScalar(string sql, List<SqlParameter> listParam = null);

        DataSet GetDataSet(string sql, List<SqlParameter> listParam = null);

        int ExecuteNonQuery(string sql, List<SqlParameter> listParam = null, bool isTransaction = false, CommandType commandType = CommandType.Text);

    }
}
