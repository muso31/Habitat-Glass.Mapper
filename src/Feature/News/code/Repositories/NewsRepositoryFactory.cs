namespace Sitecore.Feature.News.Repositories
{
    using System;
    using Sitecore.Foundation.Alerts;
    using Sitecore.Foundation.Alerts.Exceptions;
    using Glass.Mapper.Sc;
    using Glass.Mapper.Sc.IoC;
    using Sitecore.Feature.News.Models;
    using Sitecore.Foundation.Indexing.Models;
    using Sitecore.Foundation.Indexing.Repositories;

    public class NewsRepositoryFactory : INewsRepositoryFactory
    {
        private readonly ISitecoreContext context;
        private readonly ISearchServiceRepository repository;

        public NewsRepositoryFactory() 
            : this(
                  SitecoreContextFactory.Default.GetSitecoreContext(), 
                  new SearchServiceRepository(new SearchSettingsBase {Templates = new[] {Templates.NewsArticle.ID}}))
        {
            
        }
        public NewsRepositoryFactory(ISitecoreContext context, ISearchServiceRepository repository)
        {
            this.context = context;
            this.repository = repository;
        }

        public INewsRepository Create(INewsFolder folder)
        {
            try
            {
                return new NewsRepository(this.context, this.repository, folder);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidDataSourceItemException($"{AlertTexts.InvalidDataSource}", ex);
            }
        }

       
    }
}