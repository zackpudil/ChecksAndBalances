using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChecksAndBalances.Data.Models.Enum;
using ChecksAndBalances.Service.Services;
using ChecksAndBalances.Extensions;

namespace ChecksAndBalances.Web.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleService _service;

        public ArticleController(IArticleService service)
        {
            _service = service;
        }

        //
        // GET: /Article/

        public ActionResult Index(State state)
        {
            return View();
        }

        public ActionResult Get(State state, string resource)
        {
            ViewBag.CurrentState = state;

            var article = _service.Get(resource.ToContentString());
            if (article == null)
                return View("404");

            return View(article);
        }

        public ActionResult Category(State state, string resource)
        {
            return View();
        }

        public ActionResult Date(State state, string resource)
        {
            return View();
        }
    }
}
