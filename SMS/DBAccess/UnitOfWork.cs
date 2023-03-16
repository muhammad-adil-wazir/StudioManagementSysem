using SMS.DataContext;
using SMS.DBAccess.Repositories;
using SMS.DBAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.DBAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private SMSDBContext _context = null;

        public UnitOfWork()
        {
            if(_context == null)
            {
                _context = new SMSDBContext();
            }            
        }

        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IGenericRepository<T>;
            }
            IGenericRepository<T> repo = new GenericRepository<T>(_context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}