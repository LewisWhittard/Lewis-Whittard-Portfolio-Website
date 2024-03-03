using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Data.Table.Row.Column.Interface
{
    public interface IColumn
    {
        public string Value { get; set; }
        public int DisplayOrder { get; set; }
    }
}
