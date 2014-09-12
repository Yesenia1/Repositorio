using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ScrumAdmin.Models
{ 
    public class TIPORepository : ITIPORepository
    {
        Entities context = new Entities();

        public IQueryable<TIPO> All
        {
            get { return context.TIPO; }
        }

        public IQueryable<TIPO> AllIncluding(params Expression<Func<TIPO, object>>[] includeProperties)
        {
            IQueryable<TIPO> query = context.TIPO;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public TIPO Find(int id)
        {
            return context.TIPO.Find(id);
        }

        public void InsertOrUpdate(TIPO tipo)
        {
            if (tipo.ID == default(int)) {
                // New entity
                context.TIPO.Add(tipo);
            } else {
                // Existing entity
                context.Entry(tipo).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var tipo = context.TIPO.Find(id);
            context.TIPO.Remove(tipo);
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

    public interface ITIPORepository : IDisposable
    {
        IQueryable<TIPO> All { get; }
        IQueryable<TIPO> AllIncluding(params Expression<Func<TIPO, object>>[] includeProperties);
        TIPO Find(int id);
        void InsertOrUpdate(TIPO tipo);
        void Delete(int id);
        void Save();
    }
}