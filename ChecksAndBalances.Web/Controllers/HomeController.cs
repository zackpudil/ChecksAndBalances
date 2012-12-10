using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChecksAndBalances.Data.Models.Enum;
using ChecksAndBalances.Web.Models;
using ChecksAndBalances.Extensions;

namespace ChecksAndBalances.Web.Controllers
{
    public class HomeController : Controller
    {
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
    }
}
