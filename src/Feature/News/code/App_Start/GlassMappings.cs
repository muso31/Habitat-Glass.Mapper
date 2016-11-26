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
                x => x.TemplateId(Templates.NewsArticle.ID)
                    .EnforceTemplateAndBase(),
                x => x.Id(y=>y.ID),
                x => x.Field(y => y.NewsTitle).FieldId(Templates.NewsArticle.Fields.Title),
                x => x.Field(y => y.NewsDate).FieldId(Templates.NewsArticle.Fields.Date),
                x => x.Field(y => y.NewsImage).FieldId(Templates.NewsArticle.Fields.Image),
                x => x.Field(y => y.NewsSummary).FieldId(Templates.NewsArticle.Fields.Summary),
                x => x.Field(y => y.NewsBody).FieldId(Templates.NewsArticle.Fields.Body),
                x => x.Info(y => y.Url).InfoType(SitecoreInfoType.Url)
                );
        }
    }
    public class NewsFolderMap : SitecoreGlassMap<INewsFolder>
    {
        public override void Configure()
        {
            this.Map(
                x => x.TemplateId(Templates.NewsFolder.ID)
                    .EnforceTemplateAndBase(),
                x=> x.Item(y=>y.Self)
                );
        }
    }

}
