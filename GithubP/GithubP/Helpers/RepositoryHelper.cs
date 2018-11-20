using GithubP.Models.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GithubP.Helpers
{
    public static class RepositoryHelper
    {
        public static async Task<List<Repository>> GetAsync(string searchQuery)
        {
            List<Repository> results = new List<Repository>();

            string searchUrl = $"https://api.github.com/search/repositories?q={searchQuery}:%3E2017-10-22&sort=stars&order=desc";

            var client = new HttpClient();

            var uri = new Uri(searchUrl);
            var result = await client.GetStringAsync(uri);
            var reposResult = JsonConvert.DeserializeObject<RepositoryResult>(result);

            results = (from item in reposResult.Items
                       select new Repository()
                       {
                           Id = item.Id,
                           Name = item.Name,
                           Description = item.Description,
                           Owner = item.Owner,
                           Stargazers_count = item.Stargazers_count

                       }).ToList();

            return results;
        }
    }
}
