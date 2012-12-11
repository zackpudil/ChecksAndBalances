using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChecksAndBalances.Data.Models;
using ChecksAndBalances.Data.Storage.Context;

namespace ChecksAndBalances.Web.Controllers.Api
{
    public class AdminController : ApiController
    {
        private IChecksAndBalancesSession _session;

        public AdminController(IChecksAndBalancesSession session)
        {
            _session = session;
        }

        [HttpGet]
        public IEnumerable<Article> Articles(int? page)
        {
            return _session.All<Article>()
                .OrderByDescending(x => x.DatePublished)
                .Skip(page.GetValueOrDefault())
                .Take(10);
        }
    }
}
