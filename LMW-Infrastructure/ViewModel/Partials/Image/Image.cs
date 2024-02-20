using LMW_Infrastructure.Model;
using LMW_Infrastructure.ViewModel.Partials.Image.Interface;

namespace LMW_Infrastructure.ViewModel.Partials.Image
{
    public class Image : IImage
    {
        public string Value {get; set;}
        public string? ItemProp { get; set; }
        public string? Alt { get; set; }
        public HTMLContentComponentType HTMLContentComponentType { get; set; }

        private readonly ContentComponent _contentComponent;
        
        public Image(ContentComponent contentComponent)
        {
            _contentComponent = contentComponent;
            Value = PopulateValue();
            ItemProp = PopulateItemProp();
            Alt = PopulateAlt();
            HTMLContentComponentType = GetHTMLContentComponentType();
        }

        public string PopulateValue()
        {
            return _contentComponent.Value;
        }

        public string? PopulateItemProp()
        {
            return _contentComponent.ItemProp;
        }

        public string? PopulateAlt()
        {
            return _contentComponent.Alt;
        }

        public HTMLContentComponentType GetHTMLContentComponentType()
        {
            return _contentComponent.HMTLContentComponentType;
        }
    }
}
