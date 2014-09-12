using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ScrumAdmin.Models
{ 
    public class RELEASERepository : IRELEASERepository
    {
        Entities context = new Entities();

        public IQueryable<RELEASE> All
        {
            get { return context.RELEASE; }
        }

        public IQueryable<RELEASE> AllIncluding(params Expression<Func<RELEASE, object>>[] includeProperties)
        {
            IQueryable<RELEASE> query = context.RELEASE;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public RELEASE Find(int id)
        {
            return context.RELEASE.Find(id);
        }

        public void InsertOrUpdate(RELEASE release)
        {
            if (release.ID == default(int)) {
                // New entity
                context.RELEASE.Add(release);
            } else {
                // Existing entity
                context.Entry(release).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var release = context.RELEASE.Find(id);
            context.RELEASE.Remove(release);
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

    public interface IRELEASERepository : IDisposable
    {
        IQueryable<RELEASE> All { get; }
        IQueryable<RELEASE> AllIncluding(params Expression<Func<RELEASE, object>>[] includeProperties);
        RELEASE Find(int id);
        void InsertOrUpdate(RELEASE release);
        void Delete(int id);
        void Save();
    }
}