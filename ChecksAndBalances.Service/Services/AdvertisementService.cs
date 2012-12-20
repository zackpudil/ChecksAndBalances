using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChecksAndBalances.Data.Models;
using ChecksAndBalances.Data.Storage.Context;

namespace ChecksAndBalances.Service.Services
{
    public interface IAdvertisementService
    {
        IEnumerable<Advertisement> GetAdvertisements();
        Advertisement GetAdvertisement(int id);

        void Save(Advertisement advert);
        void UpdateSortOrder(IEnumerable<Advertisement> adverts);
    }

    public class AdvertisementService : IAdvertisementService
    {

        private IChecksAndBalancesSession _session;

        public AdvertisementService(IChecksAndBalancesSession session)
        {
            _session = session;
        }

        public IEnumerable<Advertisement> GetAdvertisements()
        {
            return _session.All<Advertisement>()
                .OrderByDescending(x => x.DateCreated)
                .ThenBy(x => x.SortOrder);
        }

        public Advertisement GetAdvertisement(int id)
        {
            return _session.Single<Advertisement>(x => x.Id == id);
        }

        public void Save(Advertisement advert)
        {
            advert.Articles = advert.Articles.ToList().Select(x =>
            {
                x = _session.Single<Article>(y => y.Id == x.Id) ?? x;
                x.Advertisement = advert;

                return x;
            }).ToList();
            _session.AddOrUpdate<Advertisement>(advert);

            _session.CommitChanges();
        }

        public void UpdateSortOrder(IEnumerable<Advertisement> adverts)
        {
            _session.Update<Advertisement>(adverts);
        }
    }
}
