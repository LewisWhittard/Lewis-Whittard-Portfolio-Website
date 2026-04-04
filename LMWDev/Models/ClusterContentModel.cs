using Page_Library.Page.Entities.Page.Interface;

namespace LMWDev.Models
{
    public class ClusterContentModel
    {
        public IPage Page { get; set; }
        public bool Meta { get; set; } = true;
        public bool ShouldNotBeIndexed { get; set; } = false;
        public bool BackgroundDisabled { get; set; }
        public string JsonLD { get; set; }
        public bool IsCookieConsentBannerEnabled { get; set; }

        public ClusterContentModel(IPage page, bool backgroundDisabled, string jsonLD, bool isCookieConsnetBannerEnabled)
        {
            Page = page;
            BackgroundDisabled = backgroundDisabled;
            JsonLD = jsonLD;
            IsCookieConsentBannerEnabled = isCookieConsnetBannerEnabled;
        }

        public ClusterContentModel()
        {
            
        }
    }
}
