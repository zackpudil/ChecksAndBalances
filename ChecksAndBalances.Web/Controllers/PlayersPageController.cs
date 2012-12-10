using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChecksAndBalances.Data.Models;
using ChecksAndBalances.Data.Models.Enum;
using ChecksAndBalances.Data.Storage.Context;
using ChecksAndBalances.Extensions;
using ChecksAndBalances.Web.Models;

namespace ChecksAndBalances.Web.Controllers
{
    public class PlayersPageController : Controller
    {
        private IChecksAndBalancesSession _session;

        public PlayersPageController(IChecksAndBalancesSession session)
        {
            _session = session;
        }
        //
        // GET: /PlayersPage/

        public ActionResult Index(State state)
        {
            var viewModel = new PlayersPageViewModel 
            { 
                CurrentState = state,
                Articles = _session.All<Article>()
                                .Where(x => x.States.Any(y => y.StateId == (int)state))
                                .OrderByDescending(x => x.DatePublished)
                                .Skip(0).Take(5)
            };

            return View(viewModel);
        }
    }
}
