using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.Concreate.CSHTML.Interface;
using UIFactory.Factory.Concreate.CSHTML.Table.Interfaces;

namespace UIFactory.Factory.Concreate.CSHTML.Table
{
    public class Header : ICSHTML, IHeader
    {
        public int Id { get; set; }
        public int DisplayOrder { get; set; }
        public int TableID { get; set; }
        public string Value { get; set; }
        public UIPartial? UIPartialType { get; set; }
        private readonly Infrastructure.Models.Data.Table.Header _header;

        public Header(Infrastructure.Models.Data.Table.Header Header)
        {
            _header = Header;
            Id = _header.Id;
            DisplayOrder = _header.DisplayOrder;
            TableID = _header.TableID;
            Value  = _header.Value;
        }
    }
}
