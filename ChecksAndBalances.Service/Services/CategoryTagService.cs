using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChecksAndBalances.Data.Models;
using ChecksAndBalances.Data.Models.Enum;
using ChecksAndBalances.Data.Storage.Context;

namespace ChecksAndBalances.Service.Services
{
    public interface ICategoryTagService
    {
        CategoryTag Get(int id);
        IEnumerable<CategoryTag> GetTags();

        IEnumerable<CategoryTag> GetTagsByState(State state);
        IEnumerable<Article> ArticlesByTag(State state, string tag);
    }

    public class CategoryTagService : ICategoryTagService
    {
        private IChecksAndBalancesSession _session;

        public CategoryTagService(IChecksAndBalancesSession session)
        {
            _session = session;
        }

        public CategoryTag Get(int id)
        {
            return _session.Single<CategoryTag>(x => x.Id == id);
        }

        public IEnumerable<CategoryTag> GetTags()
        {
            return _session.All<CategoryTag>().ToList();
        }

        public IEnumerable<CategoryTag> GetTagsByState(State state)
        {
            return GetByState(state).SelectMany(x => x.Tags).Distinct().OrderByDescending(x => x.Articles.Count()).ToList();
        }

        public IEnumerable<Article> ArticlesByTag(State state, string tag)
        {
            return GetByState(state).Where(x => x.Tags.Any(y => y.Name == tag)).ToList();
        }

        private IQueryable<Article> GetByState(State state)
        {
            return _session.All<Article>()
                .Where(x => x.States.Any(y => y.StateId == (int)state));
        }
    }
}
