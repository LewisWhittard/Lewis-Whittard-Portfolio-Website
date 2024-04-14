using UIFactory.Factory.CSHTML.Concrete.InfomationBlock.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.InfomationBlock
{
    public class Heading : ICSHTML, IHeading, IUI
    {
        public string Text { get; set; }
        public int DisplayOrder { get; set; }
        public int InfomationBlockid { get; set; }
        public UI? UIType { get; set; }
        public string GUID { get; set; }
        public int Level { get; set; }

        public Infrastructure.Models.Data.InfomationBlock.Heading _heading;

        public Heading(Infrastructure.Models.Data.InfomationBlock.Heading heading)
        {
            _heading = heading;
            Text = _heading.Text;
            DisplayOrder = _heading.DisplayOrder;
            InfomationBlockid = _heading.InfomationBlockid;
            GUID = _heading.GUID;
            Level = _heading.Level;
        }
    }
}
