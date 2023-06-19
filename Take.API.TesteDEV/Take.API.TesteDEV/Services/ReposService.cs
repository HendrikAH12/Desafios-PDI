using Newtonsoft.Json;
using Take.API.TesteDEV.DTOs;

namespace Take.API.TesteDEV.Services
{
    public class ReposService : IReposService
    {
        private readonly HttpClient _httpClient;

        public ReposService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.github.com/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("MyApp");
        }

        public async Task<List<RepoDTO>> GetReposAsync()
        {
            string endpoint = "users/takenet/repos";

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<dynamic>>(json);

            if (data != null) {
                var dataFilter = data
                .Where(item => item.language == "C#")
                .Skip(0)
                .Take(5);

                return dataFilter.Select(item => new RepoDTO
                {
                    Name = item.full_name,
                    Description = item.description,
                    Image = item.owner.avatar_url
                }).ToList();
            }

            return new List<RepoDTO>();
        }
    }
}
