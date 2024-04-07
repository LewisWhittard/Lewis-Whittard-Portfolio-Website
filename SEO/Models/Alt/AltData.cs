﻿using Infrastructure.Models.Data.Interface;
using SEO.Models.Alt.Interface;

namespace SEO.Models.Alt
{
    public class AltData : IAltData
    {
        public int SuperClassGUID { get; set; }
        public UIConcrete? UIConcreteType { get; set; }
        public string Page { get; set; }
        public int DisplayOrder { get; set; }
        public string Value { get; set; }
        public string DataGUID { get; set; }
    }
}
