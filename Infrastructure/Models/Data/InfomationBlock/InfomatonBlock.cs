﻿using Infrastructure.Models.Data.InfomationBlock.Interfaces;
using Infrastructure.Models.DataStandards.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Data.InfomationBlock
{
    public class InfomatonBlock : IInfomationBlock, IData
    {
        public int id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public List<Image> Images { get; set; }
        public List<Paragraph> paragraphs { get; set; }
        public List<Heading> headings { get; set; }
    }
}
