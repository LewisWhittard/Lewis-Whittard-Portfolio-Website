using UIFactory.Factory.CSHTML.Concreate.Interface;

namespace UIFactory.Factory.Interface
{
    public interface IUI
    {
        public UI? UIType { get; set; }
    }
}
