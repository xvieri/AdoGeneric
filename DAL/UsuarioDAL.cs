using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using ET;

namespace DAL
{
    public class UsuarioDAL
    {
        public List<Usuario> Listar()
        {
            var usuarios = new List<Usuario>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Colegio"].ToString()))
            {
                try
                {
                    conn.Open();
                    var query = new SqlCommand("Select * from usuario", conn);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            usuarios.Add(
                                new Usuario
                                {
                                    Id = Convert.ToInt32(dr["Id"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Apellido = dr["Apellido"].ToString(),
                                    Rol_Id = Convert.ToInt32(dr["Rol_id"])

                                }
                                );
                        }
                    }

                    foreach (var u in usuarios)
                    {
                        query = new SqlCommand("select * from rol where id = @id", conn);
                        query.Parameters.AddWithValue("@id", u.Rol_Id);

                        using (var dr = query.ExecuteReader())
                        {
                            dr.Read();
                            if (dr.HasRows)
                            {
                                u.Rol.Id = Convert.ToInt32(dr["Id"]);
                                u.Rol.Nombre = dr["Nombre"].ToString();
                            }

                        }

                    }

                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            return usuarios;
        }

        public Usuario GetById(int id)
        {
            var usuario = new Usuario();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Colegio"].ToString()))
            {
                conn.Open();
                var query = new SqlCommand("select * from usuario where id= @id", conn);
                query.Parameters.AddWithValue("@id", id);
                var dr = query.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    usuario.Id = id;
                    usuario.Nombre = dr["Nombre"].ToString();
                    usuario.Apellido = dr["Apellido"].ToString();
                    usuario.Rol_Id = Convert.ToInt32(dr["Rol_id"]);
                }

            }
            return usuario;
        }

        public bool Update(Usuario usuario)
        {
            bool response = false;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Colegio"].ToString()))
            {
                conn.Open();
                var query = new SqlCommand("update usuario set nombre = @p0, apellido = @p1, rol_id = @p2 where id= @id", conn);
                query.Parameters.AddWithValue("@p0", usuario.Nombre);
                query.Parameters.AddWithValue("@p1", usuario.Apellido);
                query.Parameters.AddWithValue("@p2 ", usuario.Rol_Id);
                query.Parameters.AddWithValue("@id", usuario.Id);
                query.ExecuteNonQuery();
                response = true;
            }
            return response;
        }

        public bool Registrar(Usuario usuario)
        {
            bool response = false;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Colegio"].ToString()))
            {
                conn.Open();
                var query = new SqlCommand("insert into usuario (nombre, apellido, rol_id) values (@p0, @p1,@p2)");
                query.Parameters.AddWithValue("@p0", usuario.Nombre);
                query.Parameters.AddWithValue("@p1", usuario.Apellido);
                query.Parameters.AddWithValue("@p2", usuario.Rol_Id);
                query.ExecuteNonQuery();
                response = true;

            }
            return response;
        }

        public bool Eliminar(int id)
        {
            bool response = false;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Colegio"].ToString()))
            {
                conn.Open();
                var query = new SqlCommand("update usuario where id =@id");
                query.Parameters.AddWithValue("@id", id);
                query.ExecuteNonQuery();
                response = true;
            }
            return true;
        }
    }

}
