using LMW_Infrastructure.Model;
using LMW_Infrastructure.ViewModel.Partials.Text.Interface;

namespace LMW_Infrastructure.ViewModel.Partials.Text
{
    public class Text : IText
    {
        public string Value {get; set;}
        public string? ItemProp { get; set; }
        public HTMLContentComponentType HTMLContentComponentType { get; set; }
        private readonly ContentComponent _contentComponent;

        public Text(ContentComponent contentComponent)
        {
            _contentComponent = contentComponent;
            Value = PopulateValue();
            ItemProp = PopulateItemProp();
            HTMLContentComponentType = PopulateHTMLContentComponentType();
        }

        public HTMLContentComponentType? PopulateHTMLContentComponentType()
        {
            return _contentComponent.HMTLContentComponentType;
        }

        public string? PopulateItemProp()
        {
            return _contentComponent.ItemProp;
        }

        public string PopulateValue()
        {
            return _contentComponent.Value;
        }
    }
}
