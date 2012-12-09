using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChecksAndBalances.Data.Models.Enum;

namespace ChecksAndBalances.Web.Models
{
    public class HomeViewModel
    {
        public State SelectedState { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
    }
}