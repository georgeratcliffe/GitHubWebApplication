using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubWebApplication.Services
{
    public interface IGitHubData
    {
        Task<User> GetSummary(string search);

        Task<dynamic> GetRepos(string user);
    }
}
