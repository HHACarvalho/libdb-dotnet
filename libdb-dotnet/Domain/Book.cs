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

        public virtual Author Author { get; set; }

        public virtual ICollection<BookEntry> BookEntries { get; set; }
    }
}