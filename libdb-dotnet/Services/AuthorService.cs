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
                Name = requestBody.Name
            };

            newAuthor = await _repo.Create(newAuthor);

            return Result.Success(AuthorDTO.Simple(newAuthor));
        }

        public async Task<Result> FindAllAuthors(int pageNumber, int pageSize)
        {
            var authorList = pageNumber > 0 && pageSize > 0 ? await _repo.FindAll(pageNumber, pageSize) : await _repo.FindAll();
            if (authorList.Count == 0)
            {
                return Result.Fail("There are no authors");
            }

            return Result.Success(authorList.ConvertAll(AuthorDTO.Simple));
        }

        public async Task<Result> FindAuthors(string name)
        {
            var authorList = await _repo.Find(name);
            if (authorList.Count == 0)
            {
                return Result.Fail("No authors with a name containing '" + name + "' were found");
            }

            return Result.Success(authorList.ConvertAll(AuthorDTO.Simple));
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

            await _repo.CommitChanges();

            return Result.Success(AuthorDTO.Simple(author));
        }

        public async Task<Result> DeleteAuthor(int id)
        {
            var author = await _repo.FindOne(id);
            if (author == null)
            {
                return Result.Fail("No author with the Id '" + id + "' was found");
            }

            await _repo.Delete(author);

            return Result.Success(AuthorDTO.Simple(author));
        }
    }
}