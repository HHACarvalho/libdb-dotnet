﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libdb_dotnet.Domain
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(48)]
        public string Name { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}