using LMW_Infrastructure.Model;
using LMW_Infrastructure.ViewModel.Partials.Text.Interface;

namespace LMW_Infrastructure.ViewModel.Partials.Text
{
    public class Text : IText
    {
        public string Value {get; set;}
        public string? ItemProp { get; set; }
        public HTMLContentComponentType? HTMLContentComponentType { get; set; }

        public Text()
        {
            Value = "";
        }

        public HTMLContentComponentType? GetHTMLContentComponentType()
        {
            throw new NotImplementedException();
        }

        public string? GetItemProp()
        {
            throw new NotImplementedException();
        }

        public string GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
