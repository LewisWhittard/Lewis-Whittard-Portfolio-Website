using UIFactory.Factory.CSHTML.Concrete.InfomationBlock.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.InfomationBlock
{
    public class Heading : ICSHTML, IHeading
    {
        public string Text { get; set; }
        public int DisplayOrder { get; set; }
        public int InfomationBlockid { get; set; }
        public UI? UIType { get; set; }
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
