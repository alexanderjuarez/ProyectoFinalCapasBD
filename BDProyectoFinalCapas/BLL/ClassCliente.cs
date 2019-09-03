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
    public class ClassCliente
    {
        public IEnumerable ListarClientes()
        {
            RepositorioGenerico<Cliente> REP = new RepositorioGenerico<Cliente>();
            return REP.ListarTodo();
        }//fin del metodo lista cliente

        public IEnumerable BuscarClienteNITyNombre(string nit, string nombre)
        {
            RepositorioGenerico<Cliente> REP = new RepositorioGenerico<Cliente>();
            return REP.ListarTodoConFiltro(b => b.NIT == nit || b.nombreCliente == nombre);
        }//fin de metodo Buscar

        public string NuevoCliente(string nombre, string apellido, string nit)
        {
            RepositorioGenerico<Cliente> REP = new RepositorioGenerico<Cliente>();
            Cliente cli = new Cliente();
            string resultado;
            try
            {
                IEnumerable busca = BuscarClienteNITyNombre(nit, nombre);
                if (busca.Cast<object>().Any())
                    resultado = "Error ya existe el cliente" + nit;
                else
                {
                    cli.nombreCliente = nombre;
                    cli.apellidoCliente = apellido;
                    cli.NIT = nit;
                    resultado = REP.Agregar(cli);
                }
            }
            catch (Exception error)
            {
                resultado = "Error" + error.Message;
            }
            return resultado;
        }

        public string ActualizarCliente(Cliente info)
        {
            string resp = "";
            RepositorioGenerico<Cliente> Rep = new RepositorioGenerico<Cliente>();
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
