using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Concrete.Table.Interfaces;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.Concrete.Table
{
    public class Header : ICSHTML, IHeader, IUI
    {
        public int? DisplayOrder { get; private set; }
        public int TableID { get; private set; }
        public string Value { get; private set; }
        public UI? UIType { get; private set; }
        public string GUID { get; private set; }

        private readonly Infrastructure.Models.Data.Table.Header _header;

        public Header(Infrastructure.Models.Data.Table.Header Header)
        {
            _header = Header;
            DisplayOrder = _header.DisplayOrder;
            TableID = _header.TableID;
            Value = _header.Value;
            GUID = _header.GUID;
        }
    }
}
