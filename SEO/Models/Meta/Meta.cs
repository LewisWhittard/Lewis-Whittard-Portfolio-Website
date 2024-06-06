﻿using Infrastructure.Models.Data.Interface;

namespace SEO.Models.Meta.Interface
{
    public class MetaData : IMetaData, IData
    {
        public int Id { get; private set; }
        public Name Name { get; private set; }
        public string Content { get; private set; }
        public string GUID { get; private set; }
        public string? Charset { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public UIConcrete? UIConcreteType { get; private set; }
        public int? DisplayOrder { get; private set; }
        public int PageId{ get; private set; }

        public MetaData(int id, Name name, string content, string guid, string? charset, bool deleted, bool inactive, UIConcrete? uiConcreteType, int? displayOrder, int pageId)
        {
            Id = id;
            Name = name;
            Content = content;
            GUID = guid;
            Charset = charset;
            Deleted = deleted;
            Inactive = inactive;
            UIConcreteType = uiConcreteType;
            DisplayOrder = displayOrder;
            PageId = pageId;
        }

        public MetaData()
        {

        }
    }
}
