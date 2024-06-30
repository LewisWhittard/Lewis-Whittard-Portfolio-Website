using Infrastructure.Models.Data.Interface;
using SEO.Model.Alt.Interface;

namespace SEO.Model.Alt
{
    public class AltData : IAltData, IData
    {
        public string UIId { get; private set; }
        public UIConcrete? UIConcreteType { get; private set; }
        public int? DisplayOrder { get; private set; }
        public string Value { get; private set; }
        public string UIId { get; private set; }
        public int Id { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }

        public AltData(string uIId, string value, int id, bool deleted, bool inactive)
        {
            UIId = uIId;
            UIConcreteType = null;
            Value = value;
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
        }

        public AltData()
        {

        }
    }
}
