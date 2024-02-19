using LMW_Infrastructure.Model;

namespace LMW_Infrastructure.ViewModel.Partials.Text.Interface
{
    public interface IText
    {
        public string Value { get; set; }
        public string? ItemProp { get; set; }
        public HTMLContentComponentType HTMLContentComponentType { get; set; }

        string PopulateValue();
        string? PopulateItemProp();
        HTMLContentComponentType PopulateHTMLContentComponentType();
    }
}
