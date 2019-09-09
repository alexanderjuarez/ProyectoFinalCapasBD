using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MODELS;
using System.Collections;
using System.Data.Entity;

namespace BLL
{
    public class ClassProducto
    {
        private ProyectoBDEntities db = new ProyectoBDEntities();
        public IEnumerable ListarProducto()
        {
            RepositorioGenerico<Producto> REP = new RepositorioGenerico<Producto>();
            var p = db.Producto.Include(pr => pr.Proveedor).Include(pr => pr.Presentacion).Include(pr => pr.TipoP);
            return REP.ListarTodo();
        }//fin del metodo listar

        public IEnumerable BuscarProducto(string nombre)
        {
            RepositorioGenerico<Producto> REP = new RepositorioGenerico<Producto>();
            return REP.ListarTodoConFiltro(b => b.nombreProducto == nombre);
        }//fin del metodo buscar proveedor

        public string NuevoProducto(string nombre, float precio, string descripcion, float descuento, int existencia, int tipoP, int Presentacion, int proveedor)
        {
            RepositorioGenerico<Producto> REP = new RepositorioGenerico<Producto>();
            Producto produc = new Producto();
            string resultado;
            try
            {
                IEnumerable busca = BuscarProducto(nombre);
                if (busca.Cast<object>().Any())
                    resultado = "Error ya existe el proveedor" + nombre;
                else
                {
                    produc.nombreProducto = nombre;
                    produc.PrecioVenta = precio;
                    produc.Descripcion = descripcion;
                    produc.descuentoProducto = descuento;
                    produc.existenciaProducto = existencia;
                    produc.tipopID = tipoP;
                    produc.PresentacionID = Presentacion;
                    produc.proveedorID = proveedor;
                    resultado = REP.Agregar(produc);
                }
            }
            catch (Exception error)
            {
                resultado = "Error" + error.Message;
            }
            return resultado;
        }//Fin del metodo agregar

        public string ActualizarProducto(Producto info)
        {
            string resp = "";
            RepositorioGenerico<Producto> Rep = new RepositorioGenerico<Producto>();
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

        public IEnumerable Consulta1()
        {
            ClassTSQL Lg = new ClassTSQL();
            return Lg.ProcedimientoTabla();
        }
    }
}
