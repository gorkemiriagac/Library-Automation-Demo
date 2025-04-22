using Library.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DTO.Dtos.AuthorDtos
{
    public class UpdateAuthorDto
    {
        public int AuthorId { get; set; }

        public string FullName { get; set; }

      

    }
}
