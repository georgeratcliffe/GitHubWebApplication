using GitHubWebApplication.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace GitHubWebApplication.Api
{
    public class GitHubController : ApiController
    {
        readonly IGitHubData _IGitHubData;

        public GitHubController()
        {
            _IGitHubData = new GitHubData();
        }

        // UNITY CONTAINER DOESN'T WORK WITH THIS CONTROLLER
        //public GitHubController(IGitHubData GitHubData)
        //{
        //    _IGitHubData = GitHubData;
        //}

        [ActionName("Summary")]
        [HttpGet]
        public async Task<IHttpActionResult> Summary(string search)
        {
            var user = await _IGitHubData.GetSummary(search);
            if (user != null)
                return Ok(new { Name = user.Name ?? "Not Found", Location = user.Location ?? "Not Found", Avatar = user.AvatarUrl ?? "Not Found" });

            return NotFound();
        }

        [ActionName("Repos")]
        [HttpGet]
        public async Task<IHttpActionResult> Repos(string search)
        {
            var data = await _IGitHubData.GetRepos(search);
            if (data != null)
                return Ok(data);

            return NotFound();
        }
    }
}
