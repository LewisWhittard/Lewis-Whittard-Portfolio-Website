using UIFactory.Factory.CSHTML.Concrete.InformationBlock.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.InformationBlock
{
    public class Heading : ICSHTML, IHeading, IUI
    {
        public string Text { get; private set; }
        public int? DisplayOrder { get; private set; }
        public int InformationBlockid { get; private set; }
        public UI? UIType { get; private set; }
        public string GUID { get; private set; }
        public int Level { get; private set; }

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
