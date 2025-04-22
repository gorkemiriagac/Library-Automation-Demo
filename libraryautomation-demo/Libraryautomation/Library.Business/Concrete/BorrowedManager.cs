using Library.Business.Abstract;
using Library.DataAccess.Abstract;
using Library.DTO.Dtos.BorrowedBookDtos;
using Library.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Concrete
{
    public class BorrowedManager : GenericManager<BorrowedBook>, IBorrowedService
    {
        private readonly IBorrowedRepository _borrowedRepository;
        public BorrowedManager(IRepository<BorrowedBook> _repository, IBorrowedRepository borrowedRepository) : base(_repository)
        {
            _borrowedRepository = borrowedRepository;
        }

        public List<BorrowedBook> TGetBookName()
         {
             return _borrowedRepository.GetBookName();
         }

        
    }
}
