using Infrastructure.Models.Data.InfomationBlock.Interfaces;
using Infrastructure.Models.DataStandards.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Data.InfomationBlock
{
    public class Heading : IData, IHeading
    {
        public int id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public string Text { get; set; }
        public int DisplayOrder { get; set; }
    }
}
