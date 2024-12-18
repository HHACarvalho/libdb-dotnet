﻿using libdb_dotnet.Domain;
using System.ComponentModel.DataAnnotations;

namespace libdb_dotnet.DTOs
{
    public class MemberCreateBody
    {
        [MaxLength(48)]
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [MaxLength(128)]
        public required string Address { get; set; }

        [Phone]
        public required string PhoneNumber { get; set; }
    }

    public class MemberUpdateBody
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [MaxLength(48)]
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [MaxLength(128)]
        public required string Address { get; set; }

        [Phone]
        public required string PhoneNumber { get; set; }
    }

    public class MemberDTO
    {
        public static object Simple(Member member)
        {
            return new
            {
                member.Id,
                member.Name,
                member.Email,
                member.Address,
                member.PhoneNumber
            };
        }

        public static object Detailed(Member member)
        {
            return new
            {
                member.Id,
                member.Name,
                member.Email,
                member.Address,
                member.PhoneNumber,
                Borrows = member.Borrows.Select(borrow => new
                {
                    borrow.Id,
                    BookTitle = borrow.BookEntry.Book.Title,
                    BorrowDate = borrow.BorrowDate.ToString("dd-MM-yyyy"),
                    DueDate = borrow.DueDate.ToString("dd-MM-yyyy"),
                    ReturnDate = borrow.ReturnDate?.ToString("dd-MM-yyyy") ?? "",
                    borrow.Fine
                }).ToArray()
            };
        }
    }
}