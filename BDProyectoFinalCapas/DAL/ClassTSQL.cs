using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS;

namespace DAL
{
  public  class ClassTSQL
    {
        ProyectoBDEntities contexto;
        public IQueryable ProcedimientoTabla()
        {
            contexto = new ProyectoBDEntities();
            var listado = (from sp in contexto.productos() select sp).ToList();
            return listado.AsQueryable();
        }

        public IQueryable sp_xmldescontar(int id, int cantidad)
        {
            contexto = new ProyectoBDEntities();
            var listado = (from sp in contexto.Descontar2(id,cantidad) select sp).ToList();
            return listado.AsQueryable();
        }
        public IQueryable sp_xmlmuestra(string cadena)
        {
            contexto = new ProyectoBDEntities();
            var listado = (from sp in contexto.muestra(cadena) select sp).ToList();
            return listado.AsQueryable();
        }

        public IQueryable sp_xmlfacturacion(string cadena, string cadean2, string cadena3)
        {
            contexto = new ProyectoBDEntities();
            var listado = (from sp in contexto.Facturacionxml(cadena,cadean2,cadena3) select sp).ToList();
            return listado.AsQueryable();
        }


    }
}
