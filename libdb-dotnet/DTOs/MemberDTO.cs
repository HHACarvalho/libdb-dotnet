using libdb_dotnet.Domain;
using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.DTOs
{
    public class MemberCreateBody
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

    public class MemberUpdateBody
    {
        [Range(1, int.MaxValue)]
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

    public class MemberDTO
    {
        public static object Simple(Member member)
        {
            return new
            {
                member.Id,
                member.Name,
                member.Email,
                member.Address,
                member.PhoneNumber
            };
        }

        public static object Detailed(Member member)
        {
            return new
            {
                member.Id,
                member.Name,
                member.Email,
                member.Address,
                member.PhoneNumber,
                Borrows = member.Borrows.Select(borrow => new
                {
                    borrow.Id,
                    borrow.BookEntry.Book.Title,
                    borrow.BorrowDate,
                    borrow.ReturnDate
                }).ToArray()
            };
        }
    }
}