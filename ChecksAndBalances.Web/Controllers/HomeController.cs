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
using ChecksAndBalances.Service.Services;

namespace ChecksAndBalances.Web.Controllers
{
    public class HomeController : Controller
    {
        private IArticleService _service;
        private ICategoryTagService _tagService;

        public HomeController(IArticleService service, ICategoryTagService tagService)
        {
            _service = service;
            _tagService = tagService;
        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(_service.GetArticles().OrderByDescending(x => x.DatePublished).Skip(0).Take(5));
        }

        [Authorize]
        public ActionResult ChooseState()
        {
            var viewModel = new HomeViewModel
            {
                States = _service.GetStates().Select(x => new SelectListItem {
                        Value = x.ToString(),
                        Text = x.ToDescription()
                    })
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChooseState(HomeViewModel viewModel)
        {
            return this.RedirectToRoute("Default", new { controller = "PlayersPage", action = "Index", state = viewModel.SelectedState });
        }

        public ActionResult SideBar(State state)
        {
            var articles = _service.ArticlesByState(state);

            var viewModel = new SideBarViewModel
            {
                CurrentState = state,
                SpotLightArticles = articles
                    .Skip(0).Take(5)
                    .Select(x => x.Title),

                RecentArticles = articles
                    .Skip(0).Take(5),

                PopularArticles = articles
                    .OrderByDescending(x => x.Views)
                    .Skip(0).Take(5),

                RecentlyCommentArticles = articles
                    .Where(x => x.Comments.Any())
                    .OrderByDescending(x => x.Comments.OrderByDescending(y => y.DateCreated).FirstOrDefault().DateCreated)
                    .Skip(0).Take(5),

                PopularTags = _tagService.GetTagsByState(state)
                    .OrderByDescending(x => x.Articles.Count)
                    .Skip(0).Take(10)
                    .Select(x => x.Name),

                LatestPhotos = articles
                    .Skip(0).Take(5)
                    .Select(x => x.ImageUrl)
            };

            return PartialView("~/Views/Shared/SideBar.cshtml", viewModel);
        }
    }
}
