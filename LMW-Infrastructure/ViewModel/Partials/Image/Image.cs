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
        private readonly Content _content;
        
        public Image(Content content)
        {
            Content _content = content;
        }

        public string GetColumnValue()
        {
            throw new NotImplementedException();
        }

        public string GetItemProp()
        {
            throw new NotImplementedException();
        }

        public string GetAlt()
        {
            throw new NotImplementedException();
        }
    }
}
