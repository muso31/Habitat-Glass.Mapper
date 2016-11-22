namespace Sitecore.Foundation.Indexing.Models
{
    using System;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Foundation.SitecoreExtensions.Extensions;

    public class SearchResult : ISearchResult
    {
        private Uri _url;

        public SearchResult(ItemUri itemUri)
        {
            this.ItemUri = itemUri;
        }

        public Item Item
        {
            get
            {
                //Doing this lazily to avoid greedy item grabs.
                return Database.GetItem(this.ItemUri);
            }
        }

        public string Title { get; set; }
        public string ContentType { get; set; }
        public string Description { get; set; }

        public Uri Url
        {
            get
            {
                return this._url ?? new Uri(this.Item.Url(), UriKind.Relative);
            }
            set
            {
                this._url = value;
            }
        }

        public string ViewName { get; set; }
        public ItemUri ItemUri { get; private set; }
    }
}