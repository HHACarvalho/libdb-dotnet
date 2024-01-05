using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.DTOs
{
    public class BookRequestBody
    {
        [Required]
        [MaxLength(13)]
        public required string ISBN { get; set; }

        [Required]
        [MaxLength(96)]
        public required string Title { get; set; }

        [Required]
        [MaxLength(48)]
        public required string Author { get; set; }
    }
}