using Library.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.WebUI.Dtos.AuthorDtos;

namespace Library.WebUI.Dtos.BookDtos
{
    public class ResultBookDtos
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public int Piece { get; set; }
        //Kitabın Yazarı - Many To One
        public int AuthorID { get; set; }
        public Author Author { get; set; }

    }
}
