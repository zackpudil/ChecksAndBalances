using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ChecksAndBalances.Data.Models;
using ChecksAndBalances.Data.Models.Enum;
using ChecksAndBalances.Data.Storage.Context;
using Newtonsoft.Json;

namespace ChecksAndBalances.Service.Services
{
    public interface IArticleService 
    {
        Article Get(int id);
        IEnumerable<Article> GetArticles();
        IEnumerable<Article> ArticlesByState(State state);

        IEnumerable<State> GetStates();
        
        Article GetArticleInProgress(int id);
        IEnumerable<Article> GetArticlesInProgress();

        ArticleInProgress SaveArticle(ArticleInProgress article);
        Article PublishArticle(Article article);
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

        public Article GetArticleInProgress(int id)
        {
            var articleInProgress = _session.Single<ArticleInProgress>(x => x.Id == id);
            if (articleInProgress == null)
                return null;

            var article = JsonConvert.DeserializeObject<Article>(articleInProgress.SavedContent, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });

            return article;
        }

        public IEnumerable<Article> GetArticlesInProgress()
        {
            var articlesInProgress = _session.All<ArticleInProgress>();

            return articlesInProgress.ToList().Select(x => JsonConvert.DeserializeObject<Article>(x.SavedContent, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            }));
        }

        public IEnumerable<Article> ArticlesByState(State state)
        {
            return GetByState(state).OrderByDescending(x => x.DatePublished).ToList();
        }

        public IEnumerable<State> GetStates()
        {
            return Enum.GetValues(typeof(State)).Cast<State>();
        }

        public ArticleInProgress SaveArticle(ArticleInProgress article)
        {
            var saveArticle = _session.Single<ArticleInProgress>(x => x.Id == article.Id) ?? article;
            saveArticle.SavedContent = article.SavedContent;

            _session.AddOrUpdate<ArticleInProgress>(article);

            _session.CommitChanges();
            return article;
        }

        public Article PublishArticle(Article article)
        {
            article.States.ToList().ForEach(x => x.Article = article);
            article.Tags.ToList().ForEach(x =>
            {
                if (!x.Articles.Any(y => y.Id == article.Id))
                    x.Articles.Add(article);
            });

            _session.AddOrUpdate(article);
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
