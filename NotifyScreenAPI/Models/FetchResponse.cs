using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotifyScreenAPI.Models
{
    public class FetchResponse
    {
        public FacebookData facebook { get; set; }
        public InstagramData instagram { get; set; }
        public YouTubeData youtube { get; set; }
    }
    public class FacebookData
    {
        public int Likes { get; set; }
        public int Comments { get; set; }
    }
    public class InstagramData
    {
        public int Follows { get; set; }
    }
    public class YouTubeData
    {
        public int Views { get; set; }
    }
}
