using Library.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Abstract
{
    public interface IBookRepository:IRepository<Book>
    {
        List<Book> GetBookWithAuthorName();
    }
}
