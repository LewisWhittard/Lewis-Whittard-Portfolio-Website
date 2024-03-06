using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Data.InfomationBlock.Interfaces
{
    public interface IHeading
    {
        public string Text { get; set; }
        public int DisplayOrder { get; set; }
    }
}
