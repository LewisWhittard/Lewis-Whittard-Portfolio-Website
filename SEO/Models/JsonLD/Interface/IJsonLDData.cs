﻿using Infrastructure.Models.Data.Interface;

namespace SEO.Models.JsonLD.Interface
{
    public interface IJsonLDData
    {
        public int DataId { get; set; }
        public UIConcrete? UIConcreteType { get; set; }
        public string Page {  get; set; }

    }
}