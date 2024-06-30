using Infrastructure.Models.Data.Interface;

namespace SEO.Model.Alt.Interface
{
    public interface IAltData
    {
        string SuperClassUIID { get; }
        UIConcrete? UIConcreteType { get; }
        string Value { get; }
        string UIID { get; }
    }
}
