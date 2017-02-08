using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DAL.Utils;

namespace DAL.Generic
{
    public class BaseCrud<Entity, Key> : IBaseCrud<Entity, Key>
    {
        private DaoTemplate daoTemplate;
        private MapperEntity<Entity> mapper;
        public string Pkey { get; set; }


        public BaseCrud()
        {
            daoTemplate = new DaoTemplate();
            mapper = new MapperEntity<Entity>();
        }
        public bool Add(Entity entity)
        {
            string strSql = AppConst.SP_INSERT + typeof(Entity).Name.ToLower() + " ";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            Dictionary<string, object> columns = mapper.ParamentersFromEntity(entity, Pkey);

            foreach (var column in columns)
            {
                SqlParameter param = new SqlParameter(column.Key, column.Value);
                sqlParameters.Add(param);
            }

            int result = daoTemplate.ExecuteNonQuery(strSql, sqlParameters, false, CommandType.StoredProcedure);

            return result > 0 ? true : false;
        }

        public bool Delete(Key value)
        {
            string strSql = AppConst.SP_DELETE + typeof(Entity).Name.ToLower() + " ";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter param = new SqlParameter(Pkey, value);
            sqlParameters.Add(param);
            int result = daoTemplate.ExecuteNonQuery(strSql, sqlParameters, false, CommandType.StoredProcedure);

            return result > 0 ? true : false;
        }

        public List<Entity> GetAll()
        {
            string strSql = AppConst.SP_SELECT + typeof(Entity).Name.ToLower() + " ";
            
            DataSet result = daoTemplate.GetDataSet(strSql, null);

            return DataTablesToList.ConvertDataTable<Entity>(result.Tables[0]);
        }

        public Entity GetById(Key id)
        {
            throw new NotImplementedException();
        }

        public bool update(Entity entity)
        {
            throw new NotImplementedException();
        }

        private List<SqlParameter> GetParameters(Entity entity)
        {
            List<SqlParameter> lstParameters = new List<SqlParameter>();

            foreach (var propertyInfo in entity.GetType().GetProperties())
            {
                var name = propertyInfo.Name;
                Object value = propertyInfo.GetValue(this, null);
                SqlParameter param = new SqlParameter(name, value);
                lstParameters.Add(param);
            }
            return lstParameters;
        }

    }
}
