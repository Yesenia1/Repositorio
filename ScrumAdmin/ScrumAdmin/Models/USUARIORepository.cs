using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ScrumAdmin.Models
{ 
    public class USUARIORepository : IUSUARIORepository
    {
        Entities context = new Entities();

        public IQueryable<USUARIO> All
        {
            get { return context.USUARIO; }
        }

        public IQueryable<USUARIO> AllIncluding(params Expression<Func<USUARIO, object>>[] includeProperties)
        {
            IQueryable<USUARIO> query = context.USUARIO;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public USUARIO Find(int id)
        {
            return context.USUARIO.Find(id);
        }

        public void InsertOrUpdate(USUARIO usuario)
        {
            if (usuario.ID == default(int)) {
                // New entity
                context.USUARIO.Add(usuario);
            } else {
                // Existing entity
                context.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var usuario = context.USUARIO.Find(id);
            context.USUARIO.Remove(usuario);
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

    public interface IUSUARIORepository : IDisposable
    {
        IQueryable<USUARIO> All { get; }
        IQueryable<USUARIO> AllIncluding(params Expression<Func<USUARIO, object>>[] includeProperties);
        USUARIO Find(int id);
        void InsertOrUpdate(USUARIO usuario);
        void Delete(int id);
        void Save();
    }
}