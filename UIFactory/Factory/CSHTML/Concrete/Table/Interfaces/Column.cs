using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFactory.Factory.CSHTML.Concrete.Table.Interfaces
{
    public interface IColumn
    {
        public string Value { get; set; }
        public int TableID { get; set; }
    }
}
