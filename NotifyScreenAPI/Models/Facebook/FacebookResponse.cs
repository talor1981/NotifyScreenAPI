using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotifyScreenAPI.Models.Facebook
{
    public class FacebookResponse
    {
        public Like Likes { get; set; }
        public Comment Comments { get; set; }
    }
    public class Like
    {
        public int Number { get; set; }      
    }
    public class Comment
    {
        public int Number { get; set; }
       
    }
}

