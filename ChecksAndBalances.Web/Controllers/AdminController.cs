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
using Newtonsoft.Json;

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

        public ActionResult Index(int? page)
        {
            return View(_service.GetArticlesInProgress());
        }

        public ActionResult Edit(int? id)
        {
            var article = _service.GetArticleInProgress(id.GetValueOrDefault()) ?? new Article();

            article.Id = id.GetValueOrDefault();

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
            var id = _service.SaveArticle(new ArticleInProgress
            {
                Id = article.Id,
                SavedContent = JsonConvert.SerializeObject(article, Formatting.None, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                })
            });

            return RedirectToAction("Edit", new { id = id.Id });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Publish([FromJson]Article article)
        {
            _service.PublishArticle(article);

            return RedirectToRoute(new { controller = "Article", action = "Get", state = article.States.First().State, resource = article.Title.ToUrlSafeString() });
        }
    }
}
