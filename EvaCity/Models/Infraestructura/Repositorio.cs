using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EvaCity.Models.Infraestructura
{
    public class Repositorio<T> : IDisposable where T : class
    {
        private EvaCityContext context = null;
        private bool disposed = false;

        protected DbSet<T> dbSet { get; set; }

        public Repositorio()
        {
            this.context = new EvaCityContext();
            this.dbSet = context.Set<T>();
        }

        public Repositorio(EvaCityContext context)
        {
            this.context = context;
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public void Insertar(T entity)
        {
            dbSet.Add(entity);
        }

        public void Eliminar(int id)
        {
            dbSet.Remove(dbSet.Find(id));
        }

        public void Eliminar(string id)
        {
            dbSet.Remove(dbSet.Find(id));
        }

        public virtual void Actualizar(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (!disposed)
            {
                context.Dispose();
                disposed = true;
            }
        }
    }
}