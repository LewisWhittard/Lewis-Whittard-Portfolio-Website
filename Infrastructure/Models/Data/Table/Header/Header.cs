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
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Inactive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DisplayOrder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int TableID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
