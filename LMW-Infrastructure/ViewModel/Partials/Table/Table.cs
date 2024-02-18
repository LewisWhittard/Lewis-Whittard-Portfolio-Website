using LMW_Infrastructure.Model;
using LMW_Infrastructure.ViewModel.Partials.Interface;
using LMW_Infrastructure.ViewModel.Partials.Table.Interface;

namespace LMWDev.Views.Partials
{
    public class Table : ITable, IPartialStandards
    {
        public string Title { get; set; }
        public string Headers { get; set; }
        public string Value { get; set; }
        public string? ItemProp { get; set; }
        public HTMLContentComponentType? HTMLContentComponentType { get; set; }

        private readonly Content _content;

        public Table(Content content)
        {
            _content = content;
            Title = GetTitle();
            Headers = GetColumnHeaders();
            Value = GetValue();
        }

        public string GetTitle()
        {
            var result = _content.Components.Where(x => x.ContentComponentType == ContentComponentType.Title).FirstOrDefault().Value;
            return result;
        }

        public string GetColumnHeaders()
        {
            var result = _content.Components
            .Where(x => x.ContentComponentType == ContentComponentType.Header)
            .OrderBy(x => x.DisplayOrder)
            .Select(x => $"<tr>{x.HMTLContentComponentType.ToString()}{x.Value}{"/" + x.HMTLContentComponentType.ToString()}</tr>")
            .Aggregate((current, next) => current + next);
            return result;
        }

        public string GetValue()
        {
            var result = _content.Components
            .Where(x => x.ContentComponentType == ContentComponentType.Value)
            .OrderBy(x => x.DisplayOrder)
            .Select(x => $"<tr>{x.HMTLContentComponentType}{x.Value}{"/" + x.HMTLContentComponentType}</tr>")
            .Aggregate((current, next) => current + next);
            return result;
        }

        public string GetItemProp()
        {
            throw new NotImplementedException();
        }

        public HTMLContentComponentType? GetHTMLContentComponentType()
        {
            throw new NotImplementedException();
        }
    }
}
