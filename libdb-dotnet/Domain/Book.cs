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
        public required string Title { get; set; }

        [Range(0, int.MaxValue)]
        public int Year { get; set; }

        [MaxLength(32)]
        public required string Genre { get; set; }

        [Url]
        public required string ImageUrl { get; set; }

        public required Author Author { get; set; }

        public required ICollection<BookEntry> BookEntries { get; set; }
    }
}