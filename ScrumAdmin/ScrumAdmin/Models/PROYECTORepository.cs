using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ScrumAdmin.Models
{ 
    public class PROYECTORepository : IPROYECTORepository
    {
        Entities context = new Entities();

        public IQueryable<PROYECTO> All
        {
            get { return context.PROYECTO; }
        }

        public IQueryable<PROYECTO> AllIncluding(params Expression<Func<PROYECTO, object>>[] includeProperties)
        {
            IQueryable<PROYECTO> query = context.PROYECTO;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public PROYECTO Find(int id)
        {
            return context.PROYECTO.Find(id);
        }

        public void InsertOrUpdate(PROYECTO proyecto)
        {
            if (proyecto.ID == default(int)) {
                // New entity
                context.PROYECTO.Add(proyecto);
            } else {
                // Existing entity
                context.Entry(proyecto).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var proyecto = context.PROYECTO.Find(id);
            context.PROYECTO.Remove(proyecto);
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

    public interface IPROYECTORepository : IDisposable
    {
        IQueryable<PROYECTO> All { get; }
        IQueryable<PROYECTO> AllIncluding(params Expression<Func<PROYECTO, object>>[] includeProperties);
        PROYECTO Find(int id);
        void InsertOrUpdate(PROYECTO proyecto);
        void Delete(int id);
        void Save();
    }
}