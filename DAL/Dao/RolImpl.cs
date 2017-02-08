using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Generic;
using ET;

namespace DAL.Dao
{
    public class RolImpl: BaseCrud<Rol, int>
    {
        public RolImpl()
        {
            this.Pkey = "Id";

        }
    }
}
