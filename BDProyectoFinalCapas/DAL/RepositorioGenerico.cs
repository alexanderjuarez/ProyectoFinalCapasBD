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

        public string Agregar(T NuevaEntidad)
        {
            string mensaje = "";
            if (NuevaEntidad == null)
                mensaje = "Error: datos vacios";
            else
            {
                using (contexto = new ProyectoBDEntities())
                {
                    var dbSet = contexto.Set<T>();
                    dbSet.Add(NuevaEntidad);
                    contexto.SaveChanges();
                    mensaje = "Se ha grabado el nuevo registro";
                }
            }
            return mensaje;

        }//Fin del metodo agregar

        public string Editar(T Entidad)
        {
            string mesaje = "";
            if (Entidad == null)
                mesaje = "Error: datos vacios";
            else
            {
                using (contexto = new ProyectoBDEntities())
                {
                    var dbSet = contexto.Set<T>();
                    dbSet.Attach(Entidad);
                    contexto.Entry(Entidad).State = EntityState.Modified;
                    contexto.SaveChanges();
                }
                mesaje = "Se ha editado la informacion";
            }
            return mesaje;
        }//fin del metodo editar

        public IQueryable<T> ListarTodoConFiltro(Expression<Func<T, bool>> filtro)
        {

            IQueryable<T> respuesta;
            using (contexto = new ProyectoBDEntities())
            {
                DbQuery<T> query = contexto.Set<T>();
                respuesta = query.Where(filtro).ToList().AsQueryable();   
            }
            return respuesta;
        
        }// fin del metodo ListarTodoConFiltro


        public IQueryable<T> GetAll()
        {
            IQueryable<T> respuesta;
            using (contexto = new ProyectoBDEntities())
            {
                var p = 
                respuesta = contexto.Set<T>().ToList().AsQueryable();
            }
            return respuesta;
        }



    }
}
