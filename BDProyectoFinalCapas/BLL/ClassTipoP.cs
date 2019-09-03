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
  public  class ClassTipoP
    {
        public IEnumerable MostrarTodo()
        {
            RepositorioGenerico<TipoP> Rep = new RepositorioGenerico<TipoP>();
            var respuesta = Rep.ListarTodo();
            return respuesta;
        }//fin del método MostrarTodo

        public IEnumerable BuscarTipo(string nombre)
        {
            RepositorioGenerico<TipoP> REP = new RepositorioGenerico<TipoP>();
            return REP.ListarTodoConFiltro(n => n.NombreTP == nombre);//puede funcionar para hacer el logeeo n.estado == nombre && n.estadocontrato==pasword (string nombre, contraseña)
        }

        public string NuevoTipo(string nombre)
        {
            RepositorioGenerico<TipoP> Rep = new RepositorioGenerico<TipoP>();
            TipoP Nuevo = new TipoP();
            string respuesta = "";
            try
            {
                IEnumerable busca = BuscarTipo(nombre);
                if (busca.Cast<object>().Any())
                    respuesta = "Error ya existe en el registro  " + nombre;
                else
                {
                    Nuevo.tipopID = Convert.ToInt32(Rep.ListarTodo().Max(m => m.tipopID) + 1);
                    Nuevo.NombreTP = nombre;
                    Rep.Agregar(Nuevo);
                    respuesta = "Se agrego correctamente el registro";
  
                }

            }
            catch (Exception error)
            {
                respuesta = "Error " + error.Message;
            }
            return respuesta;
        }//fin del metodo NUevoEstado

        public string ActualizaListado(TipoP info)
        {
            string resp = "";
            RepositorioGenerico<TipoP> Rep = new RepositorioGenerico<TipoP>();
            try
            {
                resp = Rep.Editar(info);
                return resp;
            }
            catch (Exception error)
            {
                resp = "Error al editar" + error.Message;
                return resp;
            }
        }// fin del metodo ActualizarEstado
    }
}
