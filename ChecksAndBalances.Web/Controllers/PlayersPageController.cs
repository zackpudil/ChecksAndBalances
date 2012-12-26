using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChecksAndBalances.Data.Models;
using ChecksAndBalances.Data.Models.Enum;
using ChecksAndBalances.Data.Storage.Context;
using ChecksAndBalances.Extensions;
using ChecksAndBalances.Service.Services;
using ChecksAndBalances.Web.Models;

namespace ChecksAndBalances.Web.Controllers
{
    public class PlayersPageController : Controller
    {
        private IArticleService _service;

        public PlayersPageController(IArticleService service)
        {
            _service = service;
        }
        //
        // GET: /PlayersPage/

        [Authorize]
        public ActionResult Index(State state)
        {
            var viewModel = new PlayersPageViewModel 
            { 
                CurrentState = state,
                Articles = _service.ArticlesByState(state)
                    .Skip(0).Take(5)
            };

            return View(viewModel);
        }
    }
}
