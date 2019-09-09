using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


using DAL;
using MODELS;
using System.Collections;

namespace BLL
{
    public class ClassLogin
    {
        public IEnumerable BuscarUsuario(string nombre, string clave, int idtipo)
        {
            RepositorioGenerico<IngresoUsuarios> REP = new RepositorioGenerico<IngresoUsuarios>();
            return REP.ListarTodoConFiltro(n => n.Usuario== nombre && n.Contraseña==clave && n.tlID==idtipo);//puede funcionar para hacer el logeeo n.estado == nombre && n.estadocontrato==pasword (string nombre, contraseña
            
        }


      public string Ingresar(string nombre, string clave, int idtipo)
        {
            RepositorioGenerico<IngresoUsuarios> REP = new RepositorioGenerico<IngresoUsuarios>();
            IngresoUsuarios log = new IngresoUsuarios();
            string resultado;
            

            try
            {
                IEnumerable busca = BuscarUsuario(nombre, clave, idtipo);
                if (busca.Cast<object>().Any())
                    resultado = "Bienvenido"+ idtipo ;
                    
                else
                {  
                    resultado = "Usuario y/o contraseña incorrectos";


                }
            }
            catch (Exception error)
            {
                resultado = "Error" + error.Message;
            }
            return resultado;
        }//Fin del metodo agregar*/

        public int verificar()
        {
            IngresoUsuarios nu = new IngresoUsuarios();
            int valor;
            valor = Convert.ToInt32(nu.tlID);
            return valor;
        }

    }
}
