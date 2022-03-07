using Newtonsoft.Json;
using Octokit;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GitHubWebApplication.Services
{
    public class GitHubData : IGitHubData
    {

        public async Task<User> GetSummary(string search)
        {
            var client = new GitHubClient(new Octokit.ProductHeaderValue("my-cool-app"));

            return await client.User.Get(search);
        }

        public async Task<dynamic> GetRepos(string search)
        {
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here.
                client.BaseAddress = new Uri("https://api.github.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));

                HttpResponseMessage response = await client.GetAsync($"users/{search}/repos");

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<dynamic>(result);
                    return data;

                }

                return null;
            }
        }
    }
}