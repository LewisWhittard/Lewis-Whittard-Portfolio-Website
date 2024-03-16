using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIFactory.Data.HTML.InfomationBlock.Interfaces;
using UIFactory.Data.HTML.Interface;

namespace UIFactory.Data.HTML.InfomationBlock
{
    public class Image : IImage, IData
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
    }
}
