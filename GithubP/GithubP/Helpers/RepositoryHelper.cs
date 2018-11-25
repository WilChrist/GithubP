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
        /// <summary>
        /// get repositories list from Github API, parse them and filter for removing the big part of unusefull data 
        /// before passing it to view
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns>List of Repository</returns>
        public static async Task<List<Repository>> GetAsync(string searchQuery)
        {
            List<Repository> results = new List<Repository>();

            string searchUrl = $"https://api.github.com/search/repositories?q={searchQuery}";

            var client = new HttpClient();

            var uri = new Uri(searchUrl);
            var result = await client.GetStringAsync(uri);
            var reposResult = JsonConvert.DeserializeObject<RepositoryResult>(result);

            //I will take only fields i need before to pass data to view
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
