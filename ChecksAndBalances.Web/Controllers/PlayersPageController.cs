using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChecksAndBalances.Data.Models;
using ChecksAndBalances.Data.Models.Enum;
using ChecksAndBalances.Extensions;
using ChecksAndBalances.Web.Models;

namespace ChecksAndBalances.Web.Controllers
{
    public class PlayersPageController : Controller
    {
        //
        // GET: /PlayersPage/

        public ActionResult Index(State state)
        {
            var viewModel = new PlayersPageViewModel 
            { 
                CurrentState = state,
                Articles = new List<Article>()
            };

            return View(viewModel);
        }

        public ActionResult SideBar(State state)
        {
            var viewModel = new SideBarViewModel
            {
                CurrentState = state,
                SpotLightArticles = new List<string>(),
                RecentArticles = new List<Article>(),
                PopularArticles = new List<Article>(),
                RecentlyCommentArticles = new List<Article>(),
                PopularTags = new List<string>(),
                LatestPhotos = new List<string>()
            };

            return PartialView(viewModel);
        }
    }
}
