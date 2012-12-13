using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChecksAndBalances.Data.Models;
using ChecksAndBalances.Data.Models.Enum;

namespace ChecksAndBalances.Web.Models
{
    public class SideBarViewModel
    {
        public State CurrentState { get; set; }
        public IEnumerable<string> SpotLightArticles { get; set; }

        public IEnumerable<Article> RecentArticles { get; set; }
        public IEnumerable<Article> PopularArticles { get; set; }
        public IEnumerable<Article> RecentlyCommentArticles { get; set; }

        public IEnumerable<string> LatestPhotos { get; set; }
        public IEnumerable<string> PopularTags { get; set; }
    }
}