using UIFactory.Factory.Concrete.Table.Interface;

namespace UIFactory.Factory.Concrete.Table
{
    internal class Header : IHeader
    {
        public Infrastructure.Models.Data.Table.Header HeaderData { get; private set; }

        private readonly Infrastructure.Models.Data.Table.Header _header;

        public Header(Infrastructure.Models.Data.Table.Header header)
        {
            _header = header;
            HeaderData = _header;
        }
    }
}
