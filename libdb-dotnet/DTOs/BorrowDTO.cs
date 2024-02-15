using libdb_dotnet.Domain;
using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.DTOs
{
    public class BorrowRequestBody
    {
        [Range(1, int.MaxValue)]
        public int BookId { get; set; }

        [Range(1, int.MaxValue)]
        public int MemberId { get; set; }

        public DateOnly BorrowDate { get; set; }

        public DateOnly DueDate { get; set; }

        public DateOnly ReturnDate { get; set; }

        [Range(0, float.MaxValue)]
        public float Fine { get; set; }
    }

    public class BorrowDTOFull
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string MemberName { get; set; }
        public string BorrowDate { get; set; }
        public string DueDate { get; set; }
        public string ReturnDate { get; set; }
        public float Fine { get; set; }

        public static BorrowDTOFull ToDTO(Borrow borrow)
        {
            return new BorrowDTOFull
            {
                Id = borrow.Id,
                BookTitle = borrow.Book.Title,
                MemberName = borrow.Member.Name,
                BorrowDate = borrow.BorrowDate.ToString(),
                DueDate = borrow.DueDate.ToString(),
                ReturnDate = borrow.ReturnDate?.ToString() ?? "",
                Fine = borrow.Fine
            };
        }
    }
}