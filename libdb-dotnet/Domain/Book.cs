using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libdb_dotnet.Domain
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(96)]
        public string Title { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        public Author Author { get; set; }

        public ICollection<BookEntry> BookEntries { get; set; }
    }
}