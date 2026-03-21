using Microsoft.AspNetCore.Http;
using Page_Library.Page.Repository.Interface;
using Sitemap_Library.Service.Base;
using System.Text;

namespace Sitemap_Library.Service
{
    public class SitemapXMLService : SiteMapServiceBase
    {
        public SitemapXMLService(IPageRepository pageRepository, IHttpContextAccessor http) : base(pageRepository, http)
        {
        }

        public override string RenderSitemap()
        {
            var sb = new StringBuilder();
            var pages = _pageRepository.GetPages("", "all");

            sb.AppendLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
            sb.AppendLine(@"<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"">");
            sb.AppendLine();

            sb.AppendLine("  <url>");
            sb.AppendLine($"    <loc>{_baseUrl}</loc>");
            sb.AppendLine("  </url>");
            sb.AppendLine();

            sb.AppendLine("  <url>");
            sb.AppendLine($"    <loc>{_baseUrl}/software-development</loc>");
            sb.AppendLine("  </url>");
            sb.AppendLine();

            sb.AppendLine("  <url>");
            sb.AppendLine($"    <loc>{_baseUrl}/creative-works</loc>");
            sb.AppendLine("  </url>");
            sb.AppendLine();

            foreach (var item in pages)
            {
                var first = item.Category.Split(',')[0].Trim();
                var slug = first.ToLower().Replace(" ", "-");

                sb.AppendLine("  <url>");
                sb.AppendLine($"    <loc>{_baseUrl}/{slug}/{item.ExternalId}</loc>");
                sb.AppendLine("  </url>");
                sb.AppendLine();
            }

            sb.AppendLine("</urlset>");

            return sb.ToString();
        }
    }
}
