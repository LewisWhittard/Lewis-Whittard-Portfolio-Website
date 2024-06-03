using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;

namespace SEO.Models.JsonLD
{
    public class JsonLDData : IJsonLDData, IData
    {
        public string? SuperClassGUID { get; private set; }
        public UIConcrete? UIConcreteType { get; private set; }
        public string Page { get; private set; }
        public int Id { get; private set; }
        public int? DisplayOrder { get; private set; }
        public string GUID { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }

        public JsonLDData(string? superClassGUID, UIConcrete? uiConcreteType, string page, int id, int? displayOrder, string guid, bool deleted, bool inactive)
        {
            SuperClassGUID = superClassGUID;
            UIConcreteType = uiConcreteType;
            Page = page;
            Id = id;
            DisplayOrder = displayOrder;
            GUID = guid;
            Deleted = deleted;
            Inactive = inactive;
        }

        public JsonLDData()
        {

        }
    }
}
