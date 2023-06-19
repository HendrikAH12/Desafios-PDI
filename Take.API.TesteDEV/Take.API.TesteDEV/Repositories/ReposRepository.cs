using Take.API.TesteDEV.DTOs;
using Take.API.TesteDEV.Services;

namespace Take.API.TesteDEV.Repositories
{
    public class ReposRepository : IReposRepository
    {
        private readonly IReposService _reposService;

        public ReposRepository (IReposService reposService)
        {
            _reposService = reposService ?? throw new ArgumentNullException(nameof(reposService));
        }

        public Task<List<RepoDTO>> GetReposAsync()
        {
            return _reposService.GetReposAsync();
        }
    }
}
