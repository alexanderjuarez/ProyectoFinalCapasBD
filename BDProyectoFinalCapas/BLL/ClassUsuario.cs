using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MODELS;
using DAL;

namespace BLL
{
   public class ClassUsuario
    {
        public IEnumerable MostrarTodo()
        {
            RepositorioGenerico<tipoLogin> Rep = new RepositorioGenerico<tipoLogin>();
            var respuesta = Rep.ListarTodo();
            return respuesta;
        }//fin del método MostrarTodo
    }
}
