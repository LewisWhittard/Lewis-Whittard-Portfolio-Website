using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.Concreate.CSHTML.InfomationBlock.Interfaces;
using UIFactory.Factory.Concreate.CSHTML.Interface;

namespace UIFactory.Factory.Concreate.CSHTML.InfomationBlock
{
    public class Heading : ICSHTML, IHeading
    {
        public string Text { get; set; }
        public int DisplayOrder { get; set; }
        public int InfomationBlockid { get; set; }
        public UIPartial? UIPartialType { get; set; }
        public Infrastructure.Models.Data.InfomationBlock.Heading _header;

        public Heading(Infrastructure.Models.Data.InfomationBlock.Heading header)
        {
            _header = header;
            Text = _header.Text;
            DisplayOrder = _header.DisplayOrder;
            InfomationBlockid = _header.InfomationBlockid;
        }
    }
}
