using libdb_dotnet.Domain;
using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.DTOs
{
    public class BorrowCreateBody
    {
        [Range(1, int.MaxValue)]
        public int BookEntryId { get; set; }

        [Range(1, int.MaxValue)]
        public int MemberId { get; set; }

        public required string BorrowDate { get; set; }

        public required string DueDate { get; set; }
    }

    public class BorrowUpdateBody
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        public required string ReturnDate { get; set; }
    }

    public class BorrowDTO
    {
        public static object Simple(Borrow borrow)
        {
            return new
            {
                borrow.Id,
                BookTitle = borrow.BookEntry.Book.Title,
                MemberName = borrow.Member.Name,
                BorrowDate = borrow.BorrowDate.ToString("dd-MM-yyyy"),
                DueDate = borrow.DueDate.ToString("dd-MM-yyyy"),
                ReturnDate = borrow.ReturnDate?.ToString("dd-MM-yyyy") ?? "",
                borrow.Fine
            };
        }
    }
}