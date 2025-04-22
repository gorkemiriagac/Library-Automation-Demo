using Library.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DTO.Dtos.BorrowedBookDtos
{
    public class CreateBorrowedBookDtos
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
