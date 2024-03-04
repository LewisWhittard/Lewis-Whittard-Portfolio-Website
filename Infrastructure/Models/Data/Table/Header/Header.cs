using Infrastructure.Models.Data.Table.Header.Interface;
using Infrastructure.Models.DataStandards.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Data.Table.Header
{
    public class Header : IData, IHeader
    {
        public int ID { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public int DisplayOrder { get; set; }
        public int TableID { get; set; }
        public string Value { get; set; }

        public Header()
        {
            
        }

        public Header(int iD, bool deleted, bool inactive, int displayOrder, int tableID,string value)
        {
            ID = iD;
            Deleted = deleted;
            Inactive = inactive;
            DisplayOrder = displayOrder;
            TableID = tableID;
            Value = value;
        }
    }
}
