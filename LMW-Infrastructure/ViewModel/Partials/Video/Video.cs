using LMW_Infrastructure.Model;
using LMW_Infrastructure.ViewModel.Partials.Video.Interface;

namespace LMW_Infrastructure.ViewModel.Partials.Video
{
    public class Video : IVideo
    {
        public string Value { get; set; }
        public HTMLContentComponentType HTMLContentComponentType { get; set; }
        private readonly ContentComponent _contentComponent;

        public Video(ContentComponent contentComponent)
        {
            _contentComponent = contentComponent;
            Value = contentComponent.Value;
            HTMLContentComponentType = PopulateHTMLContentComponentType();
        }

        public HTMLContentComponentType PopulateHTMLContentComponentType()
        {
            throw new NotImplementedException();
        }

        public string PopulateValue()
        {
            throw new NotImplementedException();
        }
    }
}
