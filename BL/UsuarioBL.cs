using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ET;

namespace BL
{
    public class UsuarioBL
    {
       private UsuarioDAL usuarioDal = new UsuarioDAL();

        public List<Usuario> Listar()
        {
            return usuarioDal.Listar();
        }

        public Usuario GetById(int id)
        {
            Usuario usuario = usuarioDal.GetById(id);
            return usuario;
        }

        public bool Actualizar(Usuario usuario)
        {
            bool response = usuarioDal.Update(usuario);
            return response;
        }

        public bool Registrar(Usuario usuario)
        {
            bool response = usuarioDal.Registrar(usuario);
            return response;
        }

        public bool Eliminar(int id)
        {
            bool response = usuarioDal.Eliminar(id);
            return response;
        }

    }
}
