using libdb_dotnet.Core;
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

        public async Task<Result> CreateAuthor(AuthorCreateBody requestBody)
        {
            var newAuthor = new Author
            {
                Name = requestBody.Name,
                ImageUrl = requestBody.ImageUrl
            };

            newAuthor = await _repo.Create(newAuthor);

            return Result.Success(AuthorDTO.Simple(newAuthor), 201);
        }

        public async Task<Result> FindAllAuthors(int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageNumber < 1)
            {
                pageNumber = 1;
                pageSize = 20;
            }

            var queryOutput = await _repo.FindAll(pageNumber, pageSize);
            if (queryOutput.Array.Length == 0)
            {
                return Result.Fail("There are no authors");
            }

            return Result.Success(new
            {
                total = queryOutput.TotalCount,
                array = Array.ConvertAll(queryOutput.Array, AuthorDTO.Simple)
            });
        }

        public async Task<Result> FindAuthors(int pageNumber, int pageSize, int id, string? name)
        {
            if (pageNumber < 1 || pageNumber < 1)
            {
                pageNumber = 1;
                pageSize = 20;
            }

            var queryOutput = await _repo.Find(pageNumber, pageSize, id, name);
            if (queryOutput.Array.Length == 0)
            {
                return Result.Fail("No authors matching the criteria were found");
            }

            return Result.Success(new
            {
                total = queryOutput.TotalCount,
                array = Array.ConvertAll(queryOutput.Array, AuthorDTO.Simple)
            });
        }

        public async Task<Result> FindOneAuthor(int id)
        {
            var author = await _repo.FindOne(id);
            if (author == null)
            {
                return Result.Fail("No author with the Id '" + id + "' was found");
            }

            return Result.Success(AuthorDTO.Detailed(author));
        }

        public async Task<Result> UpdateAuthor(AuthorUpdateBody requestBody)
        {
            var author = await _repo.FindOne(requestBody.Id);
            if (author == null)
            {
                return Result.Fail("No author with the Id '" + requestBody.Id + "' was found");
            }

            author.Name = requestBody.Name;
            author.ImageUrl = requestBody.ImageUrl;

            await _repo.CommitChanges();

            return Result.Success(null);
        }

        public async Task<Result> DeleteAuthor(int id)
        {
            var author = await _repo.FindOne(id);
            if (author == null)
            {
                return Result.Fail("No author with the Id '" + id + "' was found");
            }

            await _repo.Delete(author);

            return Result.Success(null);
        }
    }
}