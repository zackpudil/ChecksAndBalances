using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChecksAndBalances.Data.Models;
using ChecksAndBalances.Service.Services;
using ChecksAndBalances.Web.Attributes;

namespace ChecksAndBalances.Web.Areas.Admin.Controllers
{
    public class AdvertisementController : Controller
    {
        private IAdvertisementService _service;
        private IArticleService _articleService;
        
        public AdvertisementController(IAdvertisementService service, IArticleService articleService)
        {
            _service = service;
            _articleService = articleService;
        }
        //
        // GET: /Admin/Advertisement/

        public ActionResult Index()
        {
            return View(_service.GetAdvertisements());
        }

        public ActionResult Edit(int? id)
        {
            var advertisement = id.HasValue
                ? _service.GetAdvertisement(id.GetValueOrDefault())
                : new Advertisement();

            ViewBag.Articles = _articleService.GetArticles().ToList();

            return View(advertisement);
        }

        [HttpPost]
        public ActionResult Edit([FromJson]Advertisement advert)
        {
            _service.Save(advert);
            return RedirectToAction("Index");
        }
    }
}
