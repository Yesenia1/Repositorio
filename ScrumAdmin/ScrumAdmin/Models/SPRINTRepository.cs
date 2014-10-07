using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ScrumAdmin.Models
{ 
    public class SPRINTRepository : ISPRINTRepository
    {
        Entities context = new Entities();

        public IQueryable<SPRINT> All
        {
            get { return context.SPRINT; }
        }

        public IQueryable<SPRINT> AllIncluding(params Expression<Func<SPRINT, object>>[] includeProperties)
        {
            IQueryable<SPRINT> query = context.SPRINT;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public SPRINT Find(int id)
        {
            return context.SPRINT.Find(id);
        }

        public void InsertOrUpdate(SPRINT sprint)
        {
            if (sprint.ID == default(int)) {
                // New entity
                context.SPRINT.Add(sprint);
            } else {
                // Existing entity
                context.Entry(sprint).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var sprint = context.SPRINT.Find(id);
            context.SPRINT.Remove(sprint);
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

    public interface ISPRINTRepository : IDisposable
    {
        IQueryable<SPRINT> All { get; }
        IQueryable<SPRINT> AllIncluding(params Expression<Func<SPRINT, object>>[] includeProperties);
        SPRINT Find(int id);
        void InsertOrUpdate(SPRINT sprint);
        void Delete(int id);
        void Save();
    }
}