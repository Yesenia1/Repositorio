using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ScrumAdmin.Models
{ 
    public class STAKEHOLDERRepository : ISTAKEHOLDERRepository
    {
        Entities context = new Entities();

        public IQueryable<STAKEHOLDER> All
        {
            get { return context.STAKEHOLDER; }
        }

        public IQueryable<STAKEHOLDER> AllIncluding(params Expression<Func<STAKEHOLDER, object>>[] includeProperties)
        {
            IQueryable<STAKEHOLDER> query = context.STAKEHOLDER;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public STAKEHOLDER Find(int id)
        {
            return context.STAKEHOLDER.Find(id);
        }

        public void InsertOrUpdate(STAKEHOLDER stakeholder)
        {
            if (stakeholder.ID == default(int)) {
                // New entity
                context.STAKEHOLDER.Add(stakeholder);
            } else {
                // Existing entity
                context.Entry(stakeholder).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var stakeholder = context.STAKEHOLDER.Find(id);
            context.STAKEHOLDER.Remove(stakeholder);
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

    public interface ISTAKEHOLDERRepository : IDisposable
    {
        IQueryable<STAKEHOLDER> All { get; }
        IQueryable<STAKEHOLDER> AllIncluding(params Expression<Func<STAKEHOLDER, object>>[] includeProperties);
        STAKEHOLDER Find(int id);
        void InsertOrUpdate(STAKEHOLDER stakeholder);
        void Delete(int id);
        void Save();
    }
}