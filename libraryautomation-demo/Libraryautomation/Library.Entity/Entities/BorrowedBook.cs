using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity.Entities
{
    public class BorrowedBook
    {
        public int BorrowedBookId { get; set; }

        public int  BookId { get; set; }
        public Book Book { get; set; }

        public int MemberId { get; set; }

        public IdentityConfig Member { get; set; }
        public bool IsActive { get; set; }

        public DateTime Time {  get; set; } = DateTime.Now;
    }
}
