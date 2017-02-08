using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ET;

namespace ET
{
    public class RolBL
    {
        private RolDAL _rolDal = new RolDAL();

        public List<Rol> Listar()
        {
            return _rolDal.Listar();
        }
    }
}
