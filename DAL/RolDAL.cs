using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET;

namespace DAL
{
    public class RolDAL
    {
        public List<Rol> Listar()
        {
            var roles = new List<Rol>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Colegio"].ToString() )) 
                {
                    con.Open();
                    var query = new SqlCommand("Select * from rol", con);
                    var dr = query.ExecuteReader();
                    while (dr.Read())
                    {
                        roles.Add( new Rol
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }

                }
            }
            catch (Exception)
            {
                    
                throw;
            }

            return roles; 
        }
    }
}
