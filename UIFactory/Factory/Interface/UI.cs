using UIFactory.Factory.CSHTML.Concrete.Interface;

namespace UIFactory.Factory.Interface
{
    public interface IUI
    {
        public UI? UIType { get; set; }
        public string GUID { get; set; }
        public int DisplayOrder { get; set; }
    }
}
