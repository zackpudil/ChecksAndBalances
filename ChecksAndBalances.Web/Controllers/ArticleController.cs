using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChecksAndBalances.Data.Models.Enum;

namespace ChecksAndBalances.Web.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/

        public ActionResult Index(State state)
        {
            return View();
        }

        public ActionResult Get(State state, string resource)
        {
            return View();
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
