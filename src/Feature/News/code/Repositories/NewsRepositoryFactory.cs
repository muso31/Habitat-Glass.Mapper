namespace Sitecore.Feature.News.Repositories
{
    using System;
    using Sitecore.Foundation.Alerts;
    using Sitecore.Foundation.Alerts.Exceptions;
    using Glass.Mapper.Sc;

    public class NewsRepositoryFactory : INewsRepositoryFactory
    {
        public INewsRepository Create(ISitecoreContext contextItem)
        {
            try
            {
                return new NewsRepository(contextItem);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidDataSourceItemException($"{AlertTexts.InvalidDataSource}", ex);
            }
        }
    }
}