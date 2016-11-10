using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;

namespace Sitecore.Feature.News.Models
{
    [SitecoreType(TemplateId = Templates.NewsArticle.TemplateID)]
    public interface INewsArticle
    {
        [SitecoreId]
        Guid ID { get; set; }

        [SitecoreField]
        string NewsTitle { get; set; }

        [SitecoreField]
        DateTime NewsDate { get; set; }

        [SitecoreField]
        Image NewsImage { get; set; }

        [SitecoreField]
        string NewsSummary { get; set; }

        [SitecoreField]
        string NewsBody { get; set; }

        [SitecoreInfo(SitecoreInfoType.Url)]
        string Url { get; set; }

    }
}
