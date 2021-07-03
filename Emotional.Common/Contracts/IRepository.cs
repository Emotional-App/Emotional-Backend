using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emotional.Common.Contracts
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        List<T> GetAll();
        T Find(Expression<Func<T, bool>> expression);
        List<T> FindMany(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        public void CommitChanges();
    }
}
