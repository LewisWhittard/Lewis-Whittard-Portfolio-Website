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



        public PillarPageModel(IPage page, List<ISearchResult> results)
        {
            Page = page;
            Results = results;
        }

        public PillarPageModel()
        {
            
        }
    }
}
