using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.DTOs
{
    public struct BookRequestBody
    {
        [RegularExpression(@"^\d{10,13}$")]
        public string Isbn { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9\-:'. ]{0,96}$")]
        public string Title { get; set; }

        [Range(1, int.MaxValue)]
        public int AuthorId { get; set; }
    }
}