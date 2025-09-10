using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Content.Repository.Interface;

namespace Page_Library.Page.Entities.MetaData.Interface
{
    public interface IMeta
    {
        public string MetaTitle { get; }           // Always expected
        public string MetaDescription { get; }     // Always expected
        public List<string> MetaKeywords { get; }  // Always expected
        public IContent Content { get; }

        public void SetContent(IContentRepository contentRepository);
    }
}