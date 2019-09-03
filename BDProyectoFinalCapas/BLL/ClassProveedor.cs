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
   public class ClassProveedor
    {
        public IEnumerable ListarProveedor()
        {
            RepositorioGenerico<Proveedor> REP = new RepositorioGenerico<Proveedor>();
            return REP.ListarTodo();
        }//fin del metodo listar

        public IEnumerable BuscarProveedor(string nombre)
        {
            RepositorioGenerico<Proveedor> REP = new RepositorioGenerico<Proveedor>();
            return REP.ListarTodoConFiltro(b => b.nombreProveedor == nombre);
        }//fin del metodo buscar proveedor

        public string NuevoProveedor(string nombre, string direccion, int tel, string correo)
        {
            RepositorioGenerico<Proveedor> REP = new RepositorioGenerico<Proveedor>();
            Proveedor prove = new Proveedor();
            string resultado;
            try
            {
                IEnumerable busca = BuscarProveedor(nombre);
                if (busca.Cast<object>().Any())
                    resultado = "Error ya existe el proveedor" + nombre;
                else
                {
                    prove.nombreProveedor = nombre;
                    prove.direccionProveedor = direccion;
                    prove.telefonoProveedor = tel;
                    resultado = REP.Agregar(prove);
                }
            }
            catch (Exception error)
            {
                resultado = "Error" + error.Message;
            }
            return resultado;
        }//Fin del metodo agregar

        public string ActualizarProveedor(Proveedor info)
        {
            string resp = "";
            RepositorioGenerico<Proveedor> Rep = new RepositorioGenerico<Proveedor>();
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
        }// fin del metodo Actualizar
    }
}
