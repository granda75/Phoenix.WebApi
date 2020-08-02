

using System.Runtime.InteropServices;

namespace Phoenix.WebApi.Models
{
    public class GitHubRepositoryItem
    {
        public int id { get; set; }
        public string name { get; set; }

        public string avatar_url { get; set; }

        public Owner owner { get; set; }

    }
}