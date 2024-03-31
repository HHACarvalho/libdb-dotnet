using libdb_dotnet.Domain;
using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.DTOs
{
    public struct AuthorCreateBody
    {
        [MaxLength(48)]
        public string Name { get; set; }

        [Url]
        public string ImageUrl { get; set; }
    }

    public struct AuthorUpdateBody
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [MaxLength(48)]
        public string Name { get; set; }

        [Url]
        public string ImageUrl { get; set; }
    }

    public class AuthorDTO
    {
        public static object Simple(Author author)
        {
            return new
            {
                author.Id,
                author.Name,
                author.ImageUrl
            };
        }

        public static object Detailed(Author author)
        {
            return new
            {
                author.Id,
                author.Name,
                author.ImageUrl,
                Books = author.Books.Select(book => new
                {
                    book.Id,
                    book.Title
                }).ToArray()
            };
        }
    }
}