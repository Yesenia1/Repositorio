using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ScrumAdmin.Models
{ 
    public class ESTADORepository : IESTADORepository
    {
        Entities context = new Entities();

        public IQueryable<ESTADO> All
        {
            get { return context.ESTADO; }
        }

        public IQueryable<ESTADO> AllIncluding(params Expression<Func<ESTADO, object>>[] includeProperties)
        {
            IQueryable<ESTADO> query = context.ESTADO;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public ESTADO Find(int id)
        {
            return context.ESTADO.Find(id);
        }

        public void InsertOrUpdate(ESTADO estado)
        {
            if (estado.ID == default(int)) {
                // New entity
                context.ESTADO.Add(estado);
            } else {
                // Existing entity
                context.Entry(estado).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var estado = context.ESTADO.Find(id);
            context.ESTADO.Remove(estado);
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

    public interface IESTADORepository : IDisposable
    {
        IQueryable<ESTADO> All { get; }
        IQueryable<ESTADO> AllIncluding(params Expression<Func<ESTADO, object>>[] includeProperties);
        ESTADO Find(int id);
        void InsertOrUpdate(ESTADO estado);
        void Delete(int id);
        void Save();
    }
}