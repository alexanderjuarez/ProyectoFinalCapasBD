using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using MODELS;
using System.Collections;

namespace BLL
{
    public class ClassEmpleado
    {
        public IEnumerable ListarEmpleado()
        {
            RepositorioGenerico<Empleado> REP = new RepositorioGenerico<Empleado>();
            return REP.ListarTodo();
        }//fin del metodo lista cliente
    }
}
