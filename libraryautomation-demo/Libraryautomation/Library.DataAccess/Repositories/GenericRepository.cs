using Library.DataAccess.Abstract;
using Library.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public class GenericRepository<T>(LibraryContext _context) : IRepository<T> where T : class
    {

        public DbSet<T> Table { get => _context.Set<T>(); }
        public int BookCount()
        {
            return Table.Count();
        }

        public void Create(T entity)
        {
            Table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Table.Find(id);
            Table.Remove(entity);
            _context.SaveChanges();
        }

        public int FilterReadingBook(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).Count();
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }

        public List<T> GetList()
        {
            return Table.ToList();
        }

        public void Update(T entity)
        {
            Table.Update(entity);
            _context.SaveChanges();
        }
    }
}
