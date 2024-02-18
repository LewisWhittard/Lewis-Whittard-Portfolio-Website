using LMW_Infrastructure.Model;

namespace LMW_Infrastructure.ViewModel.Partials.Interface
{
    public interface IPartialStandards
    {
        public string Value { get; set; }
        public string? ItemProp { get; set; }
        public HTMLContentComponentType? HTMLContentComponentType { get; set; }
        
        string GetValue();
        string? GetItemProp();
        HTMLContentComponentType? GetHTMLContentComponentType();
    }
}
