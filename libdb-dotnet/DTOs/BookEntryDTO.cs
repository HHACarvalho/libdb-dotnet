using libdb_dotnet.Domain;
using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.DTOs
{
    public class BookEntryRequestBody
    {
        [MaxLength(13)]
        public string Isbn { get; set; }

        [Range(1, int.MaxValue)]
        public int BookId { get; set; }
    }

    public class BookEntryDTOFull
    {
        public int Id { get; set; }
        public string Isbn { get; set; }

        public static BookEntryDTOFull ToDTO(BookEntry bookEntry)
        {
            return new BookEntryDTOFull
            {
                Id = bookEntry.Id,
                Isbn = bookEntry.Isbn,
            };
        }
    }
}