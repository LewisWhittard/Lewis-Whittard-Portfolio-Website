using Infrastructure.Models.Data.Interface;
using SEO.Model.JsonLD.Interface;

namespace SEO.Model.JsonLD
{
    public class JsonLDData : IJsonLDData, IData
    {
        public string? SuperClassGUID { get; private set; }
        public UIConcrete? UIConcreteType { get; private set; }
        public int Id { get; private set; }
        public int? DisplayOrder { get; private set; }
        public string GUID { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }

        public JsonLDData(string? superClassGUID, int id, int? displayOrder, string guid, bool deleted, bool inactive)
        {
            SuperClassGUID = superClassGUID;
            UIConcreteType = null;
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
