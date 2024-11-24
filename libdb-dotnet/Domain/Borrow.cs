using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libdb_dotnet.Domain
{
    public class Borrow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required BookEntry BookEntry { get; set; }

        public required Member Member { get; set; }

        public DateOnly BorrowDate { get; set; }

        public DateOnly DueDate { get; set; }

        public DateOnly? ReturnDate { get; set; }

        [Range(0, (double)decimal.MaxValue)]
        public decimal Fine { get; set; }
    }
}