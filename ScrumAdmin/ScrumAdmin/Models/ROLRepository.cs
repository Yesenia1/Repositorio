using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ScrumAdmin.Models
{ 
    public class ROLRepository : IROLRepository
    {
        Entities context = new Entities();

        public IQueryable<ROL> All
        {
            get { return context.ROL; }
        }

        public IQueryable<ROL> AllIncluding(params Expression<Func<ROL, object>>[] includeProperties)
        {
            IQueryable<ROL> query = context.ROL;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public ROL Find(int id)
        {
            return context.ROL.Find(id);
        }

        public void InsertOrUpdate(ROL rol)
        {
            if (rol.ID == default(int)) {
                // New entity
                context.ROL.Add(rol);
            } else {
                // Existing entity
                context.Entry(rol).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var rol = context.ROL.Find(id);
            context.ROL.Remove(rol);
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

    public interface IROLRepository : IDisposable
    {
        IQueryable<ROL> All { get; }
        IQueryable<ROL> AllIncluding(params Expression<Func<ROL, object>>[] includeProperties);
        ROL Find(int id);
        void InsertOrUpdate(ROL rol);
        void Delete(int id);
        void Save();
    }
}