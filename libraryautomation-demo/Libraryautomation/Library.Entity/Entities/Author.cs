using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library.Entity.Entities
{
    public class Author
    {
        public int AuthorId { get; set; } 
            
        public string FullName { get; set; }
        [JsonIgnore]
        //Author içindeki Books listesini serileştirmeden hariç tut chat
        public ICollection<Book> Books { get; set; }



    }
}
