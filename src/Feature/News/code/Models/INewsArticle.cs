using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;

namespace Sitecore.Feature.News.Models
{
    public interface INewsArticle
    {
        Guid ID { get; set; }

        string NewsTitle { get; set; }

        DateTime NewsDate { get; set; }

        Image NewsImage { get; set; }

        string NewsSummary { get; set; }

        string NewsBody { get; set; }

        string Url { get; set; }

    }
}
