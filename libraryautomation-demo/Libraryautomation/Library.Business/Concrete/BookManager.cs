using Library.Business.Abstract;
using Library.DataAccess.Abstract;
using Library.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Concrete
{
    public class BookManager : GenericManager<Book>, IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookManager(IRepository<Book> _repository, IBookRepository bookRepository) : base(_repository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> TGetBookWithAuthorName()
        {
            return _bookRepository.GetBookWithAuthorName();
        }
    }
}
