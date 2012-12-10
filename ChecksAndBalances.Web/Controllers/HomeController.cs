using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChecksAndBalances.Data.Models.Enum;
using ChecksAndBalances.Web.Models;
using ChecksAndBalances.Extensions;
using ChecksAndBalances.Data.Models;
using ChecksAndBalances.Data.Storage.Context;

namespace ChecksAndBalances.Web.Controllers
{
    public class HomeController : Controller
    {
        private IChecksAndBalancesSession _session;

        public HomeController(IChecksAndBalancesSession session)
        {
            _session = session;
        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                States = Enum.GetValues(typeof(State))
                    .Cast<State>()
                    .Select(x => new SelectListItem {
                        Value = ((int)x).ToString(),
                        Text = x.ToDescription()
                    })
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel viewModel)
        {
            return this.RedirectToRoute("State", new { controller = "PlayersPage", action = "Index", state = viewModel.SelectedState });
        }

        public ActionResult SideBar(State state)
        {
            var articles = _session.All<Article>().Where(x => x.States.Any(y => y.StateId == (int)state));

            var viewModel = new SideBarViewModel
            {
                CurrentState = state,
                SpotLightArticles = articles
                    .Where(x => x.SpotLighted)
                    .OrderByDescending(x => x.DatePublished)
                    .Skip(0).Take(5)
                    .Select(x => x.Title),

                RecentArticles = articles
                    .OrderByDescending(x => x.DatePublished)
                    .Skip(0).Take(5),

                PopularArticles = articles
                    .OrderByDescending(x => x.Views)
                    .Skip(0).Take(5),

                RecentlyCommentArticles = articles
                    .Where(x => x.Comments.Any())
                    .OrderByDescending(x => x.Comments.OrderByDescending(y => y.DateCreated).FirstOrDefault().DateCreated)
                    .Skip(0).Take(5),

                PopularTags = _session.All<CategoryTag>()
                    .OrderByDescending(x => x.Articles.Count())
                    .Skip(0).Take(10)
                    .Select(x => x.Name),

                LatestPhotos = articles
                    .OrderByDescending(x => x.DatePublished)
                    .Skip(0).Take(5)
                    .Select(x => x.ImageUrl)
            };

            return PartialView("~/Views/Shared/SideBar.cshtml", viewModel);
        }
    }
}
