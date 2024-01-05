using libdb_dotnet.Core;
using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.Domain
{
    public class Book(string isbn, string title, string author) : Entity
    {
        [MaxLength(13)]
        public string ISBN { get; set; } = isbn;

        [MaxLength(96)]
        public string Title { get; set; } = title;

        [MaxLength(48)]
        public string Author { get; set; } = author;
    }
}