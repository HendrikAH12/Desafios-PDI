using Take.API.TesteDEV.DTOs;

namespace Take.API.TesteDEV.Services
{
    public interface IReposService
    {
        Task<List<RepoDTO>> GetReposAsync();
    }
}
