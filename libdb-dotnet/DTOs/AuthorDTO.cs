using libdb_dotnet.Domain;

namespace libdb_dotnet.DTOs
{
    public class AuthorDTOFull
    {
        public required int Id { get; set; }
        public required string Name { get; set; }

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