using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Entities.SearchResult.Interface;
using System.Collections.Generic;

namespace LMWDev.Models
{
    public class PillarPageModel
    {
        public IPage Page { get; set; }
        public bool Meta { get; set; } = true;
        public List<ISearchResult> Results { get; set; }
        public bool ShouldNotBeIndexed { get; set; } = false;
        public bool BackgroundDisabled { get; set; }



        public PillarPageModel(IPage page, List<ISearchResult> results, bool backgroundDisabled)
        {
            Page = page;
            Results = results;
            BackgroundDisabled = backgroundDisabled;
        }

        public PillarPageModel()
        {
            
        }
    }
}
