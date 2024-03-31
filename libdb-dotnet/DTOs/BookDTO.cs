using libdb_dotnet.Domain;
using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.DTOs
{
    public struct BookCreateBody
    {
        [MaxLength(96)]
        public string Title { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        [Range(1, int.MaxValue)]
        public int AuthorId { get; set; }
    }

    public struct BookUpdateBody
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [MaxLength(96)]
        public string Title { get; set; }

        [Url]
        public string ImageUrl { get; set; }
    }

    public class BookDTO
    {
        public static object Simple(Book book)
        {
            return new
            {
                book.Id,
                book.Title,
                book.ImageUrl,
                Author = book.Author.Name
            };
        }
    }
}