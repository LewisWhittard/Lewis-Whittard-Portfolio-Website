namespace LMWDev.Models
{
	public class LegalModel
	{
		public bool Meta { get; set; } = false;
        public bool ShouldNotBeIndexed { get; set; } = false;
        public bool BackgroundDisabled { get; set; }
        public SearchViewModel Search { get; set; }
        public string JsonLD { get; set; }
        public bool CookieApproved { get; set; }
        public bool IsCookieConsentBannerEnabled { get; set; }


        public LegalModel(bool backgroundDisabled, string jsonLD, bool cookieApproved, bool isCookieConsentBannerEnabled)
        {
            BackgroundDisabled = backgroundDisabled;
            JsonLD = jsonLD;
            CookieApproved = cookieApproved;
            IsCookieConsentBannerEnabled = isCookieConsentBannerEnabled;
        }
    }
}
