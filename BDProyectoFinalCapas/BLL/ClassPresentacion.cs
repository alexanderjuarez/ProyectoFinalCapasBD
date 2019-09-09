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
   public class ClassPresentacion
    {
        public IEnumerable MostrarTodo()
        {
            RepositorioGenerico<Presentacion> Rep = new RepositorioGenerico<Presentacion>();
            var respuesta = Rep.ListarTodo();
            return respuesta;
        }//fin del método MostrarTodo

        public IEnumerable BuscarPresentacion(string nombre)
        {
            RepositorioGenerico<Presentacion> REP = new RepositorioGenerico<Presentacion>();
            return REP.ListarTodoConFiltro(n => n.NombrePres == nombre);//puede funcionar para hacer el logeeo n.estado == nombre && n.estadocontrato==pasword (string nombre, contraseña)
        }

        public string NuevaPresentacion(string nombre)
        {
            RepositorioGenerico<Presentacion> Rep = new RepositorioGenerico<Presentacion>();
            Presentacion Nuevo = new Presentacion();
            string respuesta = "";
            try
            {
                IEnumerable busca = BuscarPresentacion(nombre);
                if (busca.Cast<object>().Any())
                    respuesta = "Error ya existe en el registro  " + nombre;
                else
                {
                    Nuevo.PresentacionID = Convert.ToInt32(Rep.ListarTodo().Max(m => m.PresentacionID) + 1);
                    Nuevo.NombrePres = nombre;
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

        public string ActualizaListado(Presentacion info)
        {
            string resp = "";
            RepositorioGenerico<Presentacion> Rep = new RepositorioGenerico<Presentacion>();
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
