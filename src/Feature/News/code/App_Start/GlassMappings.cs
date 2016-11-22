namespace Sitecore.Feature.News.Loader
{
    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Maps;
    using Sitecore.Feature.News.Models;

    public class NewsArticleMap : SitecoreGlassMap<INewsArticle>
    {
        public override void Configure()
        {
            this.Map(
                x => x.TemplateId(Templates.NewsArticle.ID),
                x => x.Id(y=>y.ID),
                x => x.Field(y => y.NewsTitle),
                x => x.Field(y => y.NewsDate),
                x => x.Field(y => y.NewsImage),
                x => x.Field(y => y.NewsSummary),
                x => x.Field(y => y.NewsBody),
                x => x.Info(y => y.Url).InfoType(SitecoreInfoType.Url)
                );
        }
    }
    public class NewsFolderMap : SitecoreGlassMap<INewsFolder>
    {
        public override void Configure()
        {
            this.Map(
                x => x.TemplateId(Templates.NewsArticle.ID)
                    .EnforceTemplateAndBase(),
                x=> x.Item(y=>y.Self)
                );
        }
    }

}
