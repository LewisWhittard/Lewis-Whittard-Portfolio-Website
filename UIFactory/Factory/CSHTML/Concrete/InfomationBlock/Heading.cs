using UIFactory.Factory.CSHTML.Concrete.InformationBlock.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.InformationBlock
{
    public class Heading : ICSHTML, IHeading, IUI
    {
        public string Text { get; set; }
        public int? DisplayOrder { get; set; }
        public int InformationBlockid { get; set; }
        public UI? UIType { get; set; }
        public string GUID { get; set; }
        public int Level { get; set; }

        public Infrastructure.Models.Data.InformationBlock.Heading _heading;

        public Heading(Infrastructure.Models.Data.InformationBlock.Heading heading)
        {
            _heading = heading;
            Text = _heading.Text;
            DisplayOrder = _heading.DisplayOrder;
            InformationBlockid = _heading.InformationBlockid;
            GUID = _heading.GUID;
            Level = _heading.Level;
        }
    }
}
