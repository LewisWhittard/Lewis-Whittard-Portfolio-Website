using Infrastructure.Models.Data.Interface;

namespace SEO.Model.Alt.Interface
{
    public interface IAltData
    {
        UIConcrete? UIConcreteType { get; }
        string Value { get; }
    }
}
