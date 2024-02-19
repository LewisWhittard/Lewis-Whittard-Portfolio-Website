using LMW_Infrastructure.Model;

namespace LMW_Infrastructure.ViewModel.Partials.Video.Interface
{
    public interface IVideo
    {
        public string Value { get; set; }
        public HTMLContentComponentType HTMLContentComponentType { get; set; }
        string PopulateValue();
        HTMLContentComponentType PopulateHTMLContentComponentType();
    }
}
