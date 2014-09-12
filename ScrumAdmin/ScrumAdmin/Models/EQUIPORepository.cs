using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ScrumAdmin.Models
{ 
    public class EQUIPORepository : IEQUIPORepository
    {
        Entities context = new Entities();

        public IQueryable<EQUIPO> All
        {
            get { return context.EQUIPO; }
        }

        public IQueryable<EQUIPO> AllIncluding(params Expression<Func<EQUIPO, object>>[] includeProperties)
        {
            IQueryable<EQUIPO> query = context.EQUIPO;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public EQUIPO Find(int id)
        {
            return context.EQUIPO.Find(id);
        }

        public void InsertOrUpdate(EQUIPO equipo)
        {
            if (equipo.ID == default(int)) {
                // New entity
                context.EQUIPO.Add(equipo);
            } else {
                // Existing entity
                context.Entry(equipo).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var equipo = context.EQUIPO.Find(id);
            context.EQUIPO.Remove(equipo);
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

    public interface IEQUIPORepository : IDisposable
    {
        IQueryable<EQUIPO> All { get; }
        IQueryable<EQUIPO> AllIncluding(params Expression<Func<EQUIPO, object>>[] includeProperties);
        EQUIPO Find(int id);
        void InsertOrUpdate(EQUIPO equipo);
        void Delete(int id);
        void Save();
    }
}