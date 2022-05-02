using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetBook.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";

        public const string Base = Root +"/" + Version;
        public static class Posts
        {
            public const string GetAll =Base +"/Posts" ;
            public const string Get =  Base + "/Posts/{PostId}";
            public const string Create =  Base + "/Posts/";
            public const string Edit =  Base + "/Posts/{PostId}";
            public const string Delete = Base + "Posts/{PostId}";

        }
    }
}
