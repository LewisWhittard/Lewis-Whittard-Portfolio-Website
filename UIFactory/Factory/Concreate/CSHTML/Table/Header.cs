using UIFactory.Concreate.CSHTML.Interface;
using UIFactory.Factory.Concreate.CSHTML.Table.Interfaces;

namespace UIFactory.Factory.Concreate.CSHTML.Table
{
    public class Header : IHTML, IHeader
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public int DisplayOrder { get; set; }
        public int TableID { get; set; }
        public string Value { get; set; }

        public Header()
        {

        }

        public Header(int id, bool deleted, bool inactive, int displayOrder, int tableID, string value)
        {
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            DisplayOrder = displayOrder;
            TableID = tableID;
            Value = value;
        }
    }
}
