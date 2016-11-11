namespace Sitecore.Feature.News.Repositories
{
    using Glass.Mapper.Sc;

    public interface INewsRepositoryFactory
    {
        INewsRepository Create(ISitecoreContext contextItem);
    }
}