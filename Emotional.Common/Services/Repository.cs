using Emotional.Common.Contracts;
using Emotional.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emotional.Common.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly EmotionalDbContext _context;

        public Repository(EmotionalDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            CommitChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            CommitChanges();
        }

        public T Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).FirstOrDefault();
        }

        public List<T> FindMany(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression)?.ToList();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            CommitChanges();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            CommitChanges();
        }

        public void CommitChanges()
        {
            _context.SaveChangesAsync();
        }
    }
}
