using libdb_dotnet.Domain;
using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.DTOs
{
    public struct BookRequestBody
    {
        [RegularExpression(@"^[a-zA-Z0-9\-:'. ]{0,96}$")]
        public string Title { get; set; }

        [Range(1, int.MaxValue)]
        public int AuthorId { get; set; }
    }

    public class BookDTOFull
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public static BookDTOFull ToDTO(Book book)
        {
            return new BookDTOFull
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author.Name
            };
        }
    }
}