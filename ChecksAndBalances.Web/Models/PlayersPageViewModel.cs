using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChecksAndBalances.Data.Models;
using ChecksAndBalances.Data.Models.Enum;

namespace ChecksAndBalances.Web.Models
{
    public class PlayersPageViewModel
    {
        public State CurrentState { get; set; }

        public IEnumerable<Article> Articles { get; set; }
    }
}