using Infrastructure.Models.Data.Interface;
using SEO.Model.Alt.Interface;

namespace SEO.Model.Alt
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

        public AltData(string superClassGUID, int? displayOrder, string value, string guid, int id, bool deleted, bool inactive)
        {
            SuperClassGUID = superClassGUID;
            UIConcreteType = null;
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
