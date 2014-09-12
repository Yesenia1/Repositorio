using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ScrumAdmin.Models
{ 
    public class USER_STORYRepository : IUSER_STORYRepository
    {
        Entities context = new Entities();

        public IQueryable<USER_STORY> All
        {
            get { return context.USER_STORY; }
        }

        public IQueryable<USER_STORY> AllIncluding(params Expression<Func<USER_STORY, object>>[] includeProperties)
        {
            IQueryable<USER_STORY> query = context.USER_STORY;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public USER_STORY Find(int id)
        {
            return context.USER_STORY.Find(id);
        }

        public void InsertOrUpdate(USER_STORY user_story)
        {
            if (user_story.ID == default(int)) {
                // New entity
                context.USER_STORY.Add(user_story);
            } else {
                // Existing entity
                context.Entry(user_story).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var user_story = context.USER_STORY.Find(id);
            context.USER_STORY.Remove(user_story);            
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

    public interface IUSER_STORYRepository : IDisposable
    {
        IQueryable<USER_STORY> All { get; }
        IQueryable<USER_STORY> AllIncluding(params Expression<Func<USER_STORY, object>>[] includeProperties);
        USER_STORY Find(int id);
        void InsertOrUpdate(USER_STORY user_story);
        void Delete(int id);
        void Save();
    }
}