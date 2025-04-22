using Library.DTO.Dtos.BorrowedBookDtos;
using Library.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Abstract
{
    public interface IBorrowedService: IGenericService<BorrowedBook>
    {
            
            List<BorrowedBook> TGetBookName();

      
    }
}
