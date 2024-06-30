﻿using Infrastructure.Models.Data.Interface;
using SEO.Model.JsonLD.Interface;

namespace SEO.Model.JsonLD
{
    public class JsonLDData : IJsonLDData, IData
    {
        public string? SuperClassUIID { get; private set; }
        public UIConcrete? UIConcreteType { get; private set; }
        public int Id { get; private set; }
        public int? DisplayOrder { get; private set; }
        public string UIID { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public int? PageId { get; private set; }
    
        public JsonLDData(string? superClassUIID, int id, bool deleted, bool inactive, int? pageId)
        {
            SuperClassUIID = superClassUIID;
            UIConcreteType = null;
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            PageId = pageId;
        }

        public JsonLDData()
        {

        }
    }
}
