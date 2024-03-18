using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIFactory.Concreate.CSHTML.Table.Interfaces;
using UIFactory.Data.HTML.Interface;

namespace UIFactory.Concreate.CSHTML.Table
{
    public class Header : IData, IHeader
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
