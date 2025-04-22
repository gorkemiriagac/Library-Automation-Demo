using Library.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DTO.Dtos.BookDtos
{
    public class CreateBookDtos
    {

        public string BookName { get; set; }
        public int Piece { get; set; }
        public int AuthorID { get; set; }

        

       

    }
}
