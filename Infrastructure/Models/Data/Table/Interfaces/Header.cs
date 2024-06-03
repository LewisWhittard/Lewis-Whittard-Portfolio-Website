using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Data.Table.Interfaces
{
    public interface IHeader
    {
        int TableID { get; }
        string Value { get; }
    }
}
