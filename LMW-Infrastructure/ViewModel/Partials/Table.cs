using LMW_Infrastructure.Model;

namespace LMWDev.Views.Partials
{
    public class Table
    {
        public string Title { get; set; }
        public string Headers { get; set; }
        public string Values { get; set; }
        private readonly Content _Content;

        public Table(Content content)
        {
            _Content = content;
            Title = GetTitle();
            Headers = GetColumnHeaders();
            Values = GetColumnValues();
        }

        public string GetTitle()
        {
            var result = _Content.Components.Where(x => x.ContentComponentType == ContentComponentType.Title).FirstOrDefault().Value;
            return result;
        }

        public string GetColumnHeaders()
        {
            var result = _Content.Components
            .Where(x => x.ContentComponentType == ContentComponentType.Header)
            .OrderBy(x => x.DisplayOrder)
            .Select(x => $"<tr>{x.HMTLContentComponentType}{x.Value}{x.HMTLContentComponentType}</tr>")
            .Aggregate((current, next) => current + next);
            return result;
        }

        public string GetColumnValues()
        {
            var result = _Content.Components
            .Where(x => x.ContentComponentType == ContentComponentType.Content)
            .OrderBy(x => x.DisplayOrder)
            .Select(x => $"<tr>{x.HMTLContentComponentType}{x.Value}{x.HMTLContentComponentType}</tr>")
            .Aggregate((current, next) => current + next);
            return result;
        }
    }
}
