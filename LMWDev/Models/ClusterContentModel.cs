using Page_Library.Page.Entities.Page.Interface;

namespace LMWDev.Models
{
    public class ClusterContentModel
    {
        public IPage Page { get; set; }
        public bool Meta { get; set; } = true;
        public bool ShouldNotBeIndexed { get; set; } = false;
        public bool BackgroundEnabled { get; set; }


        public ClusterContentModel(IPage page, bool backgroundEnabled)
        {
            Page = page;
            BackgroundEnabled = backgroundEnabled;
        }

        public ClusterContentModel()
        {
            
        }
    }
}
