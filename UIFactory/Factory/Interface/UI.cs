using UIFactory.Factory.CSHTML.Concrete.Interface;

namespace UIFactory.Factory.Interface
{
    public interface IUI
    {
        UI? UIType { get; }
        string GUID { get; }
        int? DisplayOrder { get; }
    }
}
