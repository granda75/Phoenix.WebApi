using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Phoenix.WebApi.Models;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Phoenix.WebApi.Controllers
{
    /// <summary>
    /// To enable Cors for the GitHubController for all origins, headers and methods
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GitHubController : ApiController
    {

        /// <summary>
        /// The method takes data from GitHub repository by repository name
        /// </summary>
        /// <param name="repositoryName"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<GitHubRepositoryItem>> GetGitHub(string repositoryName)
        {
            List<GitHubRepositoryItem> repoItemsList = null;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# App");

            string searchApiUrl = ConfigurationManager.AppSettings["GitHubSearchApi"];
            string searchUrlWithParam = searchApiUrl + repositoryName;

            HttpResponseMessage response = await client.GetAsync(searchUrlWithParam);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<dynamic>(jsonString)["items"];
                JArray array = (JArray)obj;
                repoItemsList = array.ToObject<List<GitHubRepositoryItem>>();
                foreach (GitHubRepositoryItem item in repoItemsList)
                {
                    item.avatar_url = item.owner.avatar_url;
                    item.owner = null;
                }
            }
            return repoItemsList;
        }

        /// <summary>
        /// The method returns bookmarked items stored in GitHubItems.json file
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<GitHubRepositoryItem> GetBookmarkedItems()
        {
            string filePath = System.Web.Hosting.HostingEnvironment.MapPath("/GitHubItems.json");
            string allText = System.IO.File.ReadAllText(filePath);
            List<GitHubRepositoryItem> list = JsonConvert.DeserializeObject<List<GitHubRepositoryItem>>(allText);
            return list;
        }

        /// <summary>
        /// The method performs repository item bookmarking and store the item in the GitHubItems.json
        /// </summary>
        /// <param name="item"></param>
        [HttpPost]
        public void BookmarkRepoItem([FromBody] GitHubRepositoryItem item)
        {
            string filePath = System.Web.Hosting.HostingEnvironment.MapPath("/GitHubItems.json");
            string allText = System.IO.File.ReadAllText(filePath);
            List<GitHubRepositoryItem> list = JsonConvert.DeserializeObject<List<GitHubRepositoryItem>>(allText);
            if ( list != null && list.Count > 0 )
            {
                GitHubRepositoryItem foundedItem = list.Where(l => l.id == item.id).Select(l => l).FirstOrDefault();
                if (foundedItem == null)
                {
                    list.Add(item);
                }
            }
            var newJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(filePath, newJson);

            //If Session was worked for subsequent request from Angular client, I was using the code to put GitHubRepositoryItem to Session
            //Dictionary<int, GitHubRepositoryItem> repoDict = (Dictionary<int, GitHubRepositoryItem>)HttpContext.Current.Session["RepoItems"];
            //if (repoDict == null)
            //{
            //    repoDict = new Dictionary<int, GitHubRepositoryItem>();
            //}
            //KeyValuePair<int, GitHubRepositoryItem> pair = new KeyValuePair<int, GitHubRepositoryItem>(item.id, item);
            //if ( !repoDict.Contains(pair) )
            //{
            //    repoDict.Add(item.id, item);
            //}
            //HttpContext.Current.Session["RepoItems"] = repoDict;
        }


    }
}
