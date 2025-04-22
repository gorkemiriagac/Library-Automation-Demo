using Library.DataAccess.Abstract;
using Library.DataAccess.Context;
using Library.DataAccess.Repositories;
using Library.DTO.Dtos.BorrowedBookDtos;
using Library.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Concrete
{
    public class BorrowedRepository : GenericRepository<BorrowedBook>, IBorrowedRepository
    {
        private readonly LibraryContext libraryContext;
        public BorrowedRepository(LibraryContext _context) : base(_context)
        {
            libraryContext = _context;
        }

         public List<BorrowedBook> GetBookName()
         {
            return libraryContext.BorrowedBooks.Include(x => x.Book).Include(x=>x.Member).ToList();
         }

       
    }
}
