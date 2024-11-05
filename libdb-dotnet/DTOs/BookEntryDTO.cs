using libdb_dotnet.Domain;
using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.DTOs
{
    public class BookEntryCreateBody
    {
        [MaxLength(13)]
        public required string Isbn { get; set; }

        [Range(1, int.MaxValue)]
        public int BookId { get; set; }
    }

    public class BookEntryUpdateBody
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        public bool IsAvailable { get; set; }
    }

    public class BookEntryDTO
    {
        public static object Simple(BookEntry bookEntry)
        {
            return new
            {
                bookEntry.Id,
                bookEntry.Isbn,
                bookEntry.IsAvailable
            };
        }
    }
}