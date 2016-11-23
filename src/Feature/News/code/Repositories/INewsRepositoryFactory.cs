namespace Sitecore.Feature.News.Repositories
{
    using Sitecore.Feature.News.Models;

    public interface INewsRepositoryFactory
    {
        INewsRepository Create(INewsFolder folder);
    }
}