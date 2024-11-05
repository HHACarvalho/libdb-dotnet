using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libdb_dotnet.Domain
{
    public class BookEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(13)]
        public required string Isbn { get; set; }

        public bool IsAvailable { get; set; }

        public required Book Book { get; set; }
    }
}