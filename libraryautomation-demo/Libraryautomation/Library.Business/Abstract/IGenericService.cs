using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        T TGetById(int id);
        List<T> TGetList();
        void TCreate(T entity);
        void TUpdate(T entity);
        void TDelete(int id);
        int TBookCount();
        int TFilterReadingBook(Expression<Func<T, bool>> predicate);
    }
}
