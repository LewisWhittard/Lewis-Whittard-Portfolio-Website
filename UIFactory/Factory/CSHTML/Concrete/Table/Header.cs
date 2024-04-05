using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.CSHTML.Concrete.Table.Interfaces;

namespace UIFactory.Factory.CSHTML.Concrete.Table
{
    public class Header : ICSHTML, IHeader
    {
        public int DisplayOrder { get; set; }
        public int TableID { get; set; }
        public string Value { get; set; }
        public UI? UIType { get; set; }
        private readonly Infrastructure.Models.Data.Table.Header _header;

        public Header(Infrastructure.Models.Data.Table.Header Header)
        {
            _header = Header;
            DisplayOrder = _header.DisplayOrder;
            TableID = _header.TableID;
            Value = _header.Value;
        }
    }
}
