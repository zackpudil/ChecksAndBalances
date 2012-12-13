using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ChecksAndBalances.Data.Models;
using ChecksAndBalances.Data.Models.Enum;
using ChecksAndBalances.Data.Storage.Context;

namespace ChecksAndBalances.Service.Services
{
    public interface IArticleService 
    {
        Article Get(int id);
        IEnumerable<Article> GetArticles();
        IEnumerable<Article> ArticlesByState(State state);

        IEnumerable<State> GetStates();
        

        Article SaveArticle(Article viewModel);
    }

    class ArticleService : IArticleService
    {
        private IChecksAndBalancesSession _session;

        public ArticleService(IChecksAndBalancesSession session)
        {
            _session = session;
        }

        public Article Get(int id)
        {
            return _session.Single<Article>(x => x.Id == id);
        }

        public IEnumerable<Article> GetArticles()
        {
            return _session.All<Article>().OrderByDescending(x => x.DatePublished).ToList();
        }

        public IEnumerable<Article> ArticlesByState(State state)
        {
            return GetByState(state).OrderByDescending(x => x.DatePublished).ToList();
        }

        public IEnumerable<State> GetStates()
        {
            return Enum.GetValues(typeof(State)).Cast<State>();
        }

        public Article SaveArticle(Article article)
        {
            article.Views = 0;
            article.DatePublished = DateTime.Now;

            _session.AddOrUpdate(article);
            _session.AddOrUpdateAll(article.Tags);
            _session.AddOrUpdateAll(article.States);
            _session.AddOrUpdateAll(article.Comments);

            _session.CommitChanges();

            return article;
        }

        private IQueryable<Article> GetByState(State state)
        {
            return _session.All<Article>()
                .Where(x => x.States.Any(y => y.StateId == (int)state));
        }

    }
}
