using Take.API.TesteDEV.DTOs;

namespace Take.API.TesteDEV.Repositories
{
    public interface IReposRepository
    {
        Task<List<RepoDTO>> GetReposAsync();
    }
}
