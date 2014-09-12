using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ScrumAdmin.Models
{ 
    public class TAREARepository : ITAREARepository
    {
        Entities context = new Entities();

        public IQueryable<TAREA> All
        {
            get { return context.TAREA; }
        }

        public IQueryable<TAREA> AllIncluding(params Expression<Func<TAREA, object>>[] includeProperties)
        {
            IQueryable<TAREA> query = context.TAREA;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public TAREA Find(int id)
        {
            return context.TAREA.Find(id);
        }

        public void InsertOrUpdate(TAREA tarea)
        {
            if (tarea.ID == default(int)) {
                // New entity
                context.TAREA.Add(tarea);
            } else {
                // Existing entity
                context.Entry(tarea).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var tarea = context.TAREA.Find(id);
            context.TAREA.Remove(tarea);
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

    public interface ITAREARepository : IDisposable
    {
        IQueryable<TAREA> All { get; }
        IQueryable<TAREA> AllIncluding(params Expression<Func<TAREA, object>>[] includeProperties);
        TAREA Find(int id);
        void InsertOrUpdate(TAREA tarea);
        void Delete(int id);
        void Save();
    }
}