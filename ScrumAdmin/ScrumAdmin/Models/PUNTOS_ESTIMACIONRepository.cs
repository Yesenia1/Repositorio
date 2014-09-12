using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ScrumAdmin.Models
{ 
    public class PUNTOS_ESTIMACIONRepository : IPUNTOS_ESTIMACIONRepository
    {
        Entities context = new Entities();

        public IQueryable<PUNTOS_ESTIMACION> All
        {
            get { return context.PUNTOS_ESTIMACION; }
        }

        public IQueryable<PUNTOS_ESTIMACION> AllIncluding(params Expression<Func<PUNTOS_ESTIMACION, object>>[] includeProperties)
        {
            IQueryable<PUNTOS_ESTIMACION> query = context.PUNTOS_ESTIMACION;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public PUNTOS_ESTIMACION Find(int id)
        {
            return context.PUNTOS_ESTIMACION.Find(id);
        }

        public void InsertOrUpdate(PUNTOS_ESTIMACION puntos_estimacion)
        {
            if (puntos_estimacion.ID == default(int)) {
                // New entity
                context.PUNTOS_ESTIMACION.Add(puntos_estimacion);
            } else {
                // Existing entity
                context.Entry(puntos_estimacion).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var puntos_estimacion = context.PUNTOS_ESTIMACION.Find(id);
            context.PUNTOS_ESTIMACION.Remove(puntos_estimacion);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IPUNTOS_ESTIMACIONRepository : IDisposable
    {
        IQueryable<PUNTOS_ESTIMACION> All { get; }
        IQueryable<PUNTOS_ESTIMACION> AllIncluding(params Expression<Func<PUNTOS_ESTIMACION, object>>[] includeProperties);
        PUNTOS_ESTIMACION Find(int id);
        void InsertOrUpdate(PUNTOS_ESTIMACION puntos_estimacion);
        void Delete(int id);
        void Save();
    }
}