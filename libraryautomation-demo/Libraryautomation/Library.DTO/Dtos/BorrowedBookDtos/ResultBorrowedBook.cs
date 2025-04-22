using Library.Entity.Entities;

namespace Library.DTO.Dtos.BorrowedBookDtos
{
    public class ResultBorrowedBook
    {
        public int BorrowedBookId { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int MemberId { get; set; }

        public IdentityConfig Member { get; set; }

        public DateTime Time { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }
}
