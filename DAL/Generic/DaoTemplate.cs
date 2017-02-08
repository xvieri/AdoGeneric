using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Generic
{
    public class DaoTemplate : IDataAccess
    {

        private SqlConnection GetConetion()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["Colegio"].ToString());
            return sqlConnection;
        }

        public SqlDataReader GetReader(string sql, List<SqlParameter> parameters = null)
        {
            SqlConnection conn = this.GetConetion();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public object GetScalar(string sql, List<SqlParameter> parameters = null)
        {
            SqlConnection conn = this.GetConetion();
            Object obj = null;
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                obj = cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw (e);
            }
            return obj;
        }

        public DataSet GetDataSet(string sql, List<SqlParameter> listParam = null)
        {
            SqlConnection conn = this.GetConetion();
            DataSet ds = null;
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                if (listParam != null)
                {
                    cmd.Parameters.AddRange(listParam.ToArray());
                }

                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception e)
            {

                throw ;
            }
            return ds;
        }

        public int ExecuteNonQuery(string sql, List<SqlParameter> listParam = null, bool isTransaction = false, CommandType commandType = CommandType.Text)
        {
            SqlConnection conn = this.GetConetion();
            SqlTransaction trans = null;
            int res = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                if (listParam != null)
                {
                    cmd.Parameters.AddRange(listParam.ToArray());
                }
                if (!isTransaction)
                {
                    trans = conn.BeginTransaction();
                    cmd.Transaction = trans;
                }

                res = cmd.ExecuteNonQuery();

                if (!isTransaction)
                    trans.Commit();

            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }
    }
}
