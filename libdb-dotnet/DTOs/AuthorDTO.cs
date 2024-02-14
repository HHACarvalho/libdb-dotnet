using libdb_dotnet.Domain;
using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.DTOs
{
    public struct AuthorRequestBody
    {
        [MaxLength(48)]
        public string Name { get; set; }
    }

    public class AuthorDTOFull
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static AuthorDTOFull ToDTO(Author author)
        {
            return new AuthorDTOFull
            {
                Id = author.Id,
                Name = author.Name
            };
        }
    }
}