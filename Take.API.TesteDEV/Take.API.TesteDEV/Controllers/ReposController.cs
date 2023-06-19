using Microsoft.AspNetCore.Mvc;
using Take.API.TesteDEV.Repositories;
using Take.API.TesteDEV.Services;

namespace Take.API.TesteDEV.Controllers
{
    [ApiController]
    [Route("api/repos")]
    public class ReposController : ControllerBase
    {
        private readonly IReposRepository _reposRepository;

        public ReposController(IReposRepository reposRepository)
        {
            _reposRepository = reposRepository ?? throw new ArgumentNullException(nameof(reposRepository));
        }

        [HttpGet]
        public async Task<ActionResult> GetRepos()
        {
            return Ok(await _reposRepository.GetReposAsync());
        }
    }
}
