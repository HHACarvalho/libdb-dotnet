using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.Domain
{
    public class Book(string isbn, string title)
    {
        [Key]
        [MaxLength(13)]
        public string Isbn { get; set; } = isbn;

        [MaxLength(96)]
        public string Title { get; set; } = title;

        public virtual Author Author { get; set; }
    }
}