﻿using Infrastructure.Models.Data.Interface;
using SEO.Models.Alt.Interface;

namespace SEO.Models.Alt
{
    public class AltData : IAltData, IData
    {
        public string SuperClassGUID { get; private set; }
        public UIConcrete? UIConcreteType { get; private set; }
        public int? DisplayOrder { get; private set; }
        public string Value { get; private set; }
        public string GUID { get; private set; }
        public int Id { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }

        public AltData(string superClassGUID, UIConcrete? uiConcreteType, int? displayOrder, string value, string guid, int id, bool deleted, bool inactive)
        {
            SuperClassGUID = superClassGUID;
            UIConcreteType = uiConcreteType;
            DisplayOrder = displayOrder;
            Value = value;
            GUID = guid;
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
        }

        public AltData()
        {

        }
    }
}
