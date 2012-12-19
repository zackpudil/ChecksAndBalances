using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChecksAndBalances.Data.Models;

namespace ChecksAndBalances.Web.Areas.Admin.Models
{
    public class ArticleViewModel
    {
        public static int ItemsPerPage = 20;
        public int CurrentPage { get; set; }

        public IEnumerable<Article> UnPublishedArticles { get; set; }
        public IEnumerable<Article> PublishedArticles { get; set; }
    }
}