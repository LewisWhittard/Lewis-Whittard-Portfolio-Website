using Page_Library.Page.Entities.Page.Interface;

namespace LMWDev.Models
{
    public class ClusterContentModel
    {
        public IPage Page { get; set; }

        public ClusterContentModel(IPage page)
        {
            Page = page;
        }

        public ClusterContentModel()
        {
            
        }
    }
}
