namespace Sitecore.Feature.News.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sitecore.Foundation.Indexing.Models;
    using Sitecore.Foundation.Indexing.Repositories;
    using Glass.Mapper.Sc;
    using Models;

    public class NewsRepository : INewsRepository
    {
        public ISitecoreContext ContextItem { get; set; }

        private readonly ISearchServiceRepository searchServiceRepository;

        public NewsRepository(ISitecoreContext contextItem) : this(contextItem, new SearchServiceRepository(new SearchSettingsBase { Templates = new[] { Templates.NewsArticle.ID } }))
        {
        }

        public NewsRepository(ISitecoreContext contextItem, ISearchServiceRepository searchServiceRepository)
        {
            if (contextItem == null)
            {
                throw new ArgumentNullException(nameof(contextItem));
            }
            //if (!contextItem.IsDerived(Templates.NewsFolder.ID))
            //{
            //  throw new ArgumentException("Item must derive from NewsFolder", nameof(contextItem));
            //}
            this.ContextItem = contextItem;
            this.searchServiceRepository = searchServiceRepository;
        }

        public IEnumerable<INewsArticle> Get()
        {
            //  var searchService = this.searchServiceRepository.Get();
            //  searchService.Settings.Root = this.ContextItem;
            //  //TODO: Refactor for scalability
            //  var results = searchService.FindAll();
            //  return results.Results.Select(x => x.Item).Where(x => x != null).OrderByDescending(i => i[Templates.NewsArticle.Fields.Date]);

            //return ContextItem.QueryRelative<INewsArticle>(".//*[@@templateid='" + Templates.NewsArticle.PageTemplateID + "']").Where(x => x != null).OrderByDescending(i => i.NewsDate);
            return ContextItem.Query<INewsArticle>("/sitecore/content/Habitat/Home/Modules/Feature/News/News//*[@@templateid='" + Templates.NewsArticle.PageTemplateID + "']").Where(x => x != null).OrderByDescending(i => i.NewsDate);
        }

        public IEnumerable<INewsArticle> GetLatestNews(int count)
        {
            //TODO: Refactor for scalability
            return this.Get().Take(count);
        }
    }
}