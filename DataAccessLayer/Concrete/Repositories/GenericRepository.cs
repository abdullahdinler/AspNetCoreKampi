using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly Context _context = new Context();
        private readonly DbSet<T> _object;

        public GenericRepository()
        {
            _object = _context.Set<T>();
        }
        public void Add(T entity)
        {
            //_context.Add(entity);
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            //_context.Remove(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public T GetById(Expression<Func<T, bool>> filter)
        {
            //return _object.Find(filter);
            return _object.SingleOrDefault(filter);
        }

        public List<T> List(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
            {
                return _object.ToList();
            }
            else
            {
                return _object.Where(filter).ToList();
            }
        }

        public void Update(T entity)
        {
            //_context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
