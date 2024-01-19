using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.Domain
{
    public class Book
    {
        [Key]
        [MaxLength(13)]
        public string Isbn { get; set; }

        [MaxLength(96)]
        public string Title { get; set; }

        public virtual Author Author { get; set; }
    }
}