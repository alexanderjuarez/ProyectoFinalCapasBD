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


    }
}
