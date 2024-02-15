using libdb_dotnet.Domain;
using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.DTOs
{
    public class MemberRequestBody
    {
        [MaxLength(48)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(128)]
        public string Address { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }

    public class MemberDTOFull
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public static MemberDTOFull ToDTO(Member member)
        {
            return new MemberDTOFull
            {
                Id = member.Id,
                Name = member.Name,
                Email = member.Email,
                Address = member.Address,
                PhoneNumber = member.PhoneNumber
            };
        }
    }
}