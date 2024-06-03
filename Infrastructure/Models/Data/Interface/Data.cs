using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Interface
{
    public interface IData
    {
        int Id { get; }
        int? DisplayOrder { get; }
        string GUID { get; }
        bool Deleted { get; }
        bool Inactive { get; }
        [JsonIgnore]
        UIConcrete? UIConcreteType { get; }
    }
}
