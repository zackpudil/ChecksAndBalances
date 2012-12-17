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
    public class ImagesController : ApiController
    {
        private IChecksAndBalancesSession _session;

        public ImagesController(IChecksAndBalancesSession session)
        {
            _session = session;
        }

        public IEnumerable<ArticleImage> Get()
        {
            return _session.All<ArticleImage>();
        }

        public ArticleImage Get(int id)
        {
            var img = _session.Single<ArticleImage>(x => x.Id == id);

            return img;
        }

        [HttpPost]
        public HttpResponseMessage Post(ArticleImage image)
        {
            _session.Add<ArticleImage>(image);
            _session.CommitChanges();

            var response = Request.CreateResponse<ArticleImage>(HttpStatusCode.Created, image);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { controller = "Images", id = image.Id }));

            return response;
        }
    }
}
