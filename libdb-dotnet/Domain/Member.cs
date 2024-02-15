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
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(128)]
        public string Address { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}