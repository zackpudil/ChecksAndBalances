using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChecksAndBalances.Data.Models.Enum;
using ChecksAndBalances.Data.Infrastructure.Extensions;
using ChecksAndBalances.Web.Models;

namespace ChecksAndBalances.Web.Controllers
{
    public class PlayersPageController : Controller
    {
        //
        // GET: /PlayersPage/

        public ActionResult Index(State state)
        {
            var viewModel = new PlayersPageViewModel { CurrentState = state };
            return View(viewModel);
        }

    }
}
