using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.DTOs
{
    public struct BookRequestBody
    {
        [RegularExpression(@"^\d{10,13}$")]
        public string Isbn { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9\-]{0,96}$")]
        public string Title { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9\-]{0,48}$")]
        public string Author { get; set; }
    }
}