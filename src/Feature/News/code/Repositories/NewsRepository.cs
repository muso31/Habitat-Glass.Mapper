namespace Sitecore.Feature.News.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sitecore.Foundation.Indexing.Repositories;
    using Glass.Mapper.Sc;
    using Models;

    public class NewsRepository : INewsRepository
    {
        private readonly ISitecoreContext _context;
        private readonly ISearchServiceRepository _searchServiceRepository;
        private readonly INewsFolder _folder;
        
        public NewsRepository(ISitecoreContext context, ISearchServiceRepository searchServiceRepository, INewsFolder folder)
        {
            if (folder == null)
            {
                throw new ArgumentNullException(nameof(folder));
            }

            this._context = context;
            this._searchServiceRepository = searchServiceRepository;
            this._folder = folder;
        }

        public IEnumerable<INewsArticle> Get()
        {
            var searchService = this._searchServiceRepository.Get();
            //TODO: Need to refactor so that the search service feature provides an interface that requires the self propety.
            searchService.Settings.Root = this._folder.Self;

            var results = searchService.FindAll();

            //TODO: This is not good, the results are greedy. Ordering needs to be passed to the search service 
            //so we can optimise the data retrieval 
            return results.Results.Select(x => 
                this._context
                    .GetItem<INewsArticle>(x.ItemUri.ItemID.Guid, x.ItemUri.Language, x.ItemUri.Version))
                    .Where(x => x != null)
                    .OrderByDescending(x=>x.NewsDate);
        }

        public IEnumerable<INewsArticle> GetLatestNews(int count)
        {
            //TODO: Refactor for scalability
            return this.Get().Take(count);
        }
    }
}