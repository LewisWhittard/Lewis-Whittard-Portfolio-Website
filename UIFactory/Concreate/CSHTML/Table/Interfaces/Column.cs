using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFactory.Concreate.CSHTML.Table.Interfaces
{
    public interface IColumn
    {
        public string Value { get; set; }
        public int TableID { get; set; }
        public int RowID { get; set; }
        public int DisplayOrder { get; set; }
    }
}
