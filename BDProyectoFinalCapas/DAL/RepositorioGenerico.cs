using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;

using MODELS;

namespace DAL
{
   public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        ProyectoBDEntities contexto;

        public IQueryable<T> ListarTodo()
        {
            IQueryable<T> respuesta;
            using (contexto = new ProyectoBDEntities())
            {
                respuesta = contexto.Set<T>().ToList().AsQueryable();
            }
            return respuesta;
        }

    }
}
