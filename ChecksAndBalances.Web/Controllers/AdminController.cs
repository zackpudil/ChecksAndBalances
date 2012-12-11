using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChecksAndBalances.Data.Models;
using ChecksAndBalances.Data.Models.Enum;
using ChecksAndBalances.Data.Storage.Context;
using ChecksAndBalances.Web.Models;
using ChecksAndBalances.Extensions;

namespace ChecksAndBalances.Web.Controllers
{
    public class AdminController : Controller
    {
        private IChecksAndBalancesSession _session;

        public AdminController(IChecksAndBalancesSession session)
        {
            _session = session;
        }

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            var viewModel = new AdminArticleListViewModel()
            {
                Articles = _session.All<Article>().OrderByDescending(x => x.DatePublished).Skip(0).Take(10),
                CurrentPage = 1
            };
            viewModel.TotalArticles = 10; //_session.All<Article>().Count();

            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            var article = id.HasValue ?
                _session.Single<Article>(x => x.Id == id.GetValueOrDefault()) : new Article();

            ViewBag.States = Enum.GetValues(typeof(State))
                .Cast<State>()
                .Select(x => new SelectListItem { Value = ((int)x).ToString(), Text = x.ToDescription() });

            ViewBag.Tags = _session.All<CategoryTag>();

            return View(article);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Article article)
        {
            if(article.Id == 0)
                _session.Add<Article>(article);

            article.DatePublished = DateTime.Now;
            article.Views = 0;

            _session.CommitChanges();
            return View(article);
        }

    }
}
