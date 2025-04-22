using Library.DataAccess.Abstract;
using Library.DataAccess.Context;
using Library.DataAccess.Repositories;
using Library.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Concrete
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly LibraryContext libraryContext;
        public BookRepository(LibraryContext _context) : base(_context)
        {
            libraryContext = _context;
        }

        public List<Book> GetBookWithAuthorName()
        {
            return libraryContext.Books.Include(x => x.Author).ToList();
        }
    }
}
