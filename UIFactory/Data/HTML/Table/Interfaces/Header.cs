﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFactory.Data.HTML.Table.Interfaces
{
    public interface IHeader
    {
        public int TableID { get; set; }
        public string Value { get; set; }
        public int DisplayOrder { get; set; }
    }
}
