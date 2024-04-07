using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.CSHTML.Concrete.Table.Interfaces;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.Table
{
    public class Header : ICSHTML, IHeader, IUI
    {
        public int DisplayOrder { get; set; }
        public int TableID { get; set; }
        public string Value { get; set; }
        public UI? UIType { get; set; }
        public string GUID { get; set; }

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
