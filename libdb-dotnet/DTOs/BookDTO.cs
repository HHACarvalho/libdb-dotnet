using libdb_dotnet.Domain;

namespace libdb_dotnet.DTOs
{
    public class BookDTOFull
    {
        public required string Isbn { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }

        public static BookDTOFull ToDTO(Book book)
        {
            return new BookDTOFull
            {
                Isbn = book.Isbn,
                Title = book.Title,
                Author = book.Author
            };
        }
    }

    public class BookDTOPartial
    {
        public required string Isbn { get; set; }
        public required string Title { get; set; }

        public static BookDTOPartial ToDTO(Book book)
        {
            return new BookDTOPartial
            {
                Isbn = book.Isbn,
                Title = book.Title
            };
        }
    }
}