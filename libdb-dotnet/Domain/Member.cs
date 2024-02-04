using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.Domain
{
    public class Member
    {
        [Key]
        public string Email { get; set; }

        [MaxLength(48)]
        public string Name { get; set; }
    }
}