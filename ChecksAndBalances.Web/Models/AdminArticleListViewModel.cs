using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChecksAndBalances.Data.Models;

namespace ChecksAndBalances.Web.Models
{
    public class AdminArticleListViewModel
    {
        public int TotalArticles { get; set; }
        public int? CurrentPage { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}