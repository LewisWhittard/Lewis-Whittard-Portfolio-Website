using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFactory.Factory.Concreate.CSHTML.InfomationBlock.Interfaces
{
    public interface IImage
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
    }
}
