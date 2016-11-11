namespace Sitecore.Feature.News.Repositories
{
    using System.Collections.Generic;
    using Models;

    public interface INewsRepository
    {
        IEnumerable<INewsArticle> Get();
        IEnumerable<INewsArticle> GetLatestNews(int count);
    }
}