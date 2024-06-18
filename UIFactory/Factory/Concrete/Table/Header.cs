using UIFactory.Factory.Concrete.Table.Interface;

namespace UIFactory.Factory.Concrete.Table
{
    public class Header : IHeader, IConcreteUI
    {
        public Infrastructure.Models.Data.Table.Header HeaderData { get; private set; }

        public Header(Infrastructure.Models.Data.Table.Header Header)
        {
            HeaderData = Header;
        }
    }
}
