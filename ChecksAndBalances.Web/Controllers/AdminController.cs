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
using ChecksAndBalances.Web.Attributes;
using ChecksAndBalances.Service.Services;

namespace ChecksAndBalances.Web.Controllers
{
    public class AdminController : Controller
    {
        IArticleService _service;
        ICategoryTagService _tagService;

        public AdminController(IArticleService service, ICategoryTagService tagService)
        {
            _service = service;
            _tagService = tagService;
        }

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            var articles = _service.GetArticles();
            var viewModel = new AdminArticleListViewModel()
            {
                Articles = articles,
                CurrentPage = 1
            };
            viewModel.TotalArticles = articles.Count();

            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            var article = id.HasValue ?
                _service.Get(id.Value) : new Article();

            ViewBag.States = _service.GetStates().Select(x => new SelectListItem
            {
                Value = ((int)x).ToString(),
                Text = x.ToDescription()
            });

            ViewBag.Tags = _tagService.GetTags();

            return View(article);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit([FromJson]Article article)
        {
            article.Content = Server.UrlDecode(article.Content);

            _service.SaveArticle(article);

            return RedirectToAction("Edit", new { id = article.Id });
        }

    }
}
