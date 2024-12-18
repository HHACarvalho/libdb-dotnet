﻿using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.DTOs;
using libdb_dotnet.Repos.IRepos;
using libdb_dotnet.Services.IServices;

namespace libdb_dotnet.Services
{
    public class BookEntryService : IBookEntryService
    {
        private readonly IBookRepo _bookRepo;
        private readonly IBookEntryRepo _bookEntryRepo;

        public BookEntryService(IBookRepo bookRepo, IBookEntryRepo bookEntryRepo)
        {
            _bookRepo = bookRepo;
            _bookEntryRepo = bookEntryRepo;
        }

        public async Task<Result> CreateBookEntry(BookEntryCreateBody requestBody)
        {
            var book = await _bookRepo.FindOne(requestBody.BookId);
            if (book == null)
            {
                return Result.Fail("Book not found", 400);
            }

            var newBookEntry = new BookEntry
            {
                Isbn = requestBody.Isbn,
                Book = book,
                IsAvailable = true
            };

            newBookEntry = await _bookEntryRepo.Create(newBookEntry);

            return Result.Success(BookEntryDTO.Simple(newBookEntry), 201);
        }

        public async Task<Result> FindAllBookEntries(int pageNumber, int pageSize)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 16;

            var queryOutput = await _bookEntryRepo.FindAll(pageNumber, pageSize);
            if (queryOutput.Array.Length == 0)
            {
                return Result.Fail("There are no book entries");
            }

            return Result.Success(new
            {
                total = queryOutput.TotalCount,
                array = Array.ConvertAll(queryOutput.Array, BookEntryDTO.Simple)
            });
        }

        public async Task<Result> FindOneBookEntry(int id)
        {
            var bookEntry = await _bookEntryRepo.FindOne(id);
            if (bookEntry == null)
            {
                return Result.Fail("No book entry with the Id '" + id + "' was found");
            }

            return Result.Success(BookEntryDTO.Simple(bookEntry));
        }

        public async Task<Result> UpdateBookEntry(BookEntryUpdateBody requestBody)
        {
            var bookEntry = await _bookEntryRepo.FindOne(requestBody.Id);
            if (bookEntry == null)
            {
                return Result.Fail("No book entry with the Id '" + requestBody.Id + "' was found");
            }

            bookEntry.IsAvailable = requestBody.IsAvailable;

            await _bookEntryRepo.CommitChanges();

            return Result.Success(null);
        }

        public async Task<Result> DeleteBookEntry(int id)
        {
            var bookEntry = await _bookEntryRepo.FindOne(id);
            if (bookEntry == null)
            {
                return Result.Fail("No book entry with the Id '" + id + "' was found");
            }

            if (!bookEntry.IsAvailable)
            {
                return Result.Fail("The book entry with the Id '" + id + "' isn't available at the moment");
            }

            await _bookEntryRepo.Delete(bookEntry);

            return Result.Success(null);
        }
    }
}