﻿using Library.Business.Abstract;
using Library.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Concrete
{
    public class GenericManager<T>(IRepository<T> _repository) : IGenericService<T> where T : class
    {
        public int TBookCount()
        {
            return _repository.BookCount();
        }

        public void TCreate(T entity)
        {
           _repository.Create(entity);
        }

        public void TDelete(int id)
        {
            _repository.Delete(id);
        }

        public int TFilterReadingBook(Expression<Func<T, bool>> predicate)
        {
          return _repository.FilterReadingBook(predicate);
        }

        public T TGetById(int id)
        {
           return _repository.GetById(id);
        }

        public List<T> TGetList()
        {
           return _repository.GetList();
        }

        public void TUpdate(T entity)
        {
            _repository.Update(entity);
        }
    }
}
