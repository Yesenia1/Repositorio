using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ScrumAdmin.Models
{ 
    public class PRIORIDADRepository : IPRIORIDADRepository
    {
        Entities context = new Entities();

        public IQueryable<PRIORIDAD> All
        {
            get { return context.PRIORIDAD; }
        }

        public IQueryable<PRIORIDAD> AllIncluding(params Expression<Func<PRIORIDAD, object>>[] includeProperties)
        {
            IQueryable<PRIORIDAD> query = context.PRIORIDAD;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public PRIORIDAD Find(int id)
        {
            return context.PRIORIDAD.Find(id);
        }

        public void InsertOrUpdate(PRIORIDAD prioridad)
        {
            if (prioridad.ID == default(int)) {
                // New entity
                context.PRIORIDAD.Add(prioridad);
            } else {
                // Existing entity
                context.Entry(prioridad).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var prioridad = context.PRIORIDAD.Find(id);
            context.PRIORIDAD.Remove(prioridad);
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

    public interface IPRIORIDADRepository : IDisposable
    {
        IQueryable<PRIORIDAD> All { get; }
        IQueryable<PRIORIDAD> AllIncluding(params Expression<Func<PRIORIDAD, object>>[] includeProperties);
        PRIORIDAD Find(int id);
        void InsertOrUpdate(PRIORIDAD prioridad);
        void Delete(int id);
        void Save();
    }
}