using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIFactory.Data.HTML.InfomationBlock.Interfaces;
using UIFactory.Data.HTML.Interface;

namespace UIFactory.Data.HTML.InfomationBlock
{
    public class InfomatonBlock : IInfomationBlock, IData
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public List<Image> Images { get; set; }
        public List<Paragraph> paragraphs { get; set; }
        public List<Heading> headings { get; set; }
    }
}
