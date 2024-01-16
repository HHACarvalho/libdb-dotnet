using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.DTOs
{
    public struct AuthorRequestBody
    {
        [RegularExpression(@"^[a-zA-Z0-9\-. ]{0,48}$")]
        public string Name { get; set; }
    }
}