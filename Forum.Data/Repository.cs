using Forum.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }
        public bool Add(T entity)
        {
            _context.Set<T>().Add(entity);
            int result = _context.SaveChanges();
            return result!=0 ? true : false;
        }

        public bool Delete(int id)
        {
            _context.Set<T>().Remove(_context.Set<T>().Find(id));
            int result = _context.SaveChanges();
            return result != 0 ? true : false;
        }

        public bool Edit(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            int result = _context.SaveChanges();
            return result != 0 ? true : false;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> GetAllById(int id)
        {
            return (IEnumerable<T>)_context.Set<T>().Find(id);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
