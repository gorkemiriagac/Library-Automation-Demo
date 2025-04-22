using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
        //Tüm entity sınıflarım için ortak CRUD İşlemlerinin yer aldığı kısım.
    {
        T GetById(int id);
        List<T> GetList();
        void Create(T entity);

        void Update(T entity);

        void Delete(int id);

        int BookCount();

        int FilterReadingBook(Expression<Func<T, bool>> predicate);





    }
}
