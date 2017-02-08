using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }

        public Rol Rol { get; set; }

        public int Rol_Id { get; set; }

        public Usuario()
        {
            Rol = new Rol();
        }

    }
}
