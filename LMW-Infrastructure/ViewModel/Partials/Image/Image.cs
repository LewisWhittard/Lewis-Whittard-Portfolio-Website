using LMW_Infrastructure.Model;
using LMW_Infrastructure.ViewModel.Partials.Image.Interface;
using LMW_Infrastructure.ViewModel.Partials.Interface;

namespace LMW_Infrastructure.ViewModel.Partials.Image
{
    public class Image : IImage, IPartialStandards
    {
        public string Value {get; set;}
        public string? ItemProp { get; set; }
        public string? Alt { get; set; }
        private readonly ContentComponent _contentComponent;
        
        public Image(ContentComponent contentComponent)
        {
            ContentComponent _contentComponent = contentComponent;
        }

        public string GetColumnValue()
        {
            string result = _contentComponent.Value;
            return result;
        }

        public string GetItemProp()
        {
            string result = _contentComponent.ItemProp;
            return result;
        }

        public string GetAlt()
        {
            string result = _contentComponent.Alt;
            return result;
        }
    }
}
