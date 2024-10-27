using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libdb_dotnet.Domain
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(48)]
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [MaxLength(128)]
        public required string Address { get; set; }

        [Phone]
        public required string PhoneNumber { get; set; }

        public required ICollection<Borrow> Borrows { get; set; }
    }
}