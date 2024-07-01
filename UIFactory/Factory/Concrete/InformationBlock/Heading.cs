using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.Concrete.InformationBlock.Interface;
using UIFactory.Factory.Concrete.Interface;

namespace UIFactory.Factory.Concrete.InformationBlock
{
    public class Heading : IHeading, IConcreteUI
    {
        public Infrastructure.Models.Data.InformationBlock.Heading HeadingData { get; private set; }
        public int? DisplayOrder { get; private set; }
        public UIConcrete UIConcreteType { get; private set; }

        private readonly Infrastructure.Models.Data.InformationBlock.Heading _heading;

        public Heading(Infrastructure.Models.Data.InformationBlock.Heading heading)
        {
            _heading = heading;
            HeadingData = _heading;
            DisplayOrder = (int)_heading.DisplayOrder;
            UIConcreteType = (UIConcrete)_heading.UIConcreteType;
        }
    }
}
