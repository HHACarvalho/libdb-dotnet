﻿using libdb_dotnet.Core;
using libdb_dotnet.Domain;
using libdb_dotnet.DTOs;
using libdb_dotnet.Repos.IRepos;
using libdb_dotnet.Services.IServices;

namespace libdb_dotnet.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepo _repo;

        public AuthorService(IAuthorRepo repo)
        {
            _repo = repo;
        }

        public async Task<Result<AuthorDTOFull>> CreateAuthor(AuthorRequestBody requestBody)
        {
            var newAuthor = new Author
            {
                Name = requestBody.Name
            };

            newAuthor = await _repo.Create(newAuthor);

            return Result<AuthorDTOFull>.Success(AuthorDTOFull.ToDTO(newAuthor));
        }

        public async Task<Result<List<AuthorDTOFull>>> FindAllAuthors(int pageNumber, int pageSize)
        {
            var authorList = pageNumber > 0 && pageSize > 0 ? await _repo.FindAll(pageNumber, pageSize) : await _repo.FindAll();
            if (authorList.Count == 0)
            {
                return Result<List<AuthorDTOFull>>.Fail("There are no authors");
            }

            return Result<List<AuthorDTOFull>>.Success(authorList.ConvertAll(AuthorDTOFull.ToDTO));
        }

        public async Task<Result<List<AuthorDTOFull>>> FindAuthors(string name)
        {
            var authorList = await _repo.Find(name);
            if (authorList.Count == 0)
            {
                return Result<List<AuthorDTOFull>>.Fail("No authors with a name containing '" + name + "' were found");
            }

            return Result<List<AuthorDTOFull>>.Success(authorList.ConvertAll(AuthorDTOFull.ToDTO));
        }

        public async Task<Result<AuthorDTOFull>> FindOneAuthor(int id)
        {
            var author = await _repo.FindOne(id);
            if (author == null)
            {
                return Result<AuthorDTOFull>.Fail("No author with the ID '" + id + "' was found");
            }

            return Result<AuthorDTOFull>.Success(AuthorDTOFull.ToDTO(author));
        }

        public async Task<Result<AuthorDTOFull>> UpdateAuthor(int id, AuthorRequestBody requestBody)
        {
            var author = await _repo.FindOne(id);
            if (author == null)
            {
                return Result<AuthorDTOFull>.Fail("No author with the ID '" + id + "' was found");
            }

            author.Name = requestBody.Name;

            await _repo.CommitChanges();

            return Result<AuthorDTOFull>.Success(AuthorDTOFull.ToDTO(author));
        }

        public async Task<Result<AuthorDTOFull>> DeleteAuthor(int id)
        {
            var author = await _repo.FindOne(id);
            if (author == null)
            {
                return Result<AuthorDTOFull>.Fail("No author with the ID '" + id + "' was found");
            }

            await _repo.Delete(author);

            return Result<AuthorDTOFull>.Success(AuthorDTOFull.ToDTO(author));
        }
    }
}