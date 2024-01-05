using libdb_dotnet.Domain;

namespace libdb_dotnet.DTOs
{
    public class BookDTOFull
    {
        public required string ID;
        public required string ISBN;
        public required string Title;
        public required string Author;

        public static BookDTOFull ToDTO(Book book)
        {
            return new BookDTOFull
            {
                ID = book.ID.ToString(),
                ISBN = book.ISBN,
                Title = book.Title,
                Author = book.Author
            };
        }
    }
}