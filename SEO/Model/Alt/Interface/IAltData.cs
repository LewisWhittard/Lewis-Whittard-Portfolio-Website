using Infrastructure.Models.Data.Interface;

namespace SEO.Model.Alt.Interface
{
    public interface IAltData
    {
        string UIId { get; }
        UIConcrete? UIConcreteType { get; }
        string Value { get; }
        string UIId { get; }
    }
}
