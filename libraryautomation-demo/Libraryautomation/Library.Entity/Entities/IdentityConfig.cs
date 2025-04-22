using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Library.Entity.Entities
{
    public class IdentityConfig:IdentityUser<int>
    {
       
        public string FullName { get; set; }

        public bool isAdmin { get; set; }

        [JsonIgnore]
        public ICollection<BorrowedBook> BorrowedBooks { get; set; }

    }
}
