using UIFactory.Factory.Concrete.Interface;

namespace UIFactory.Factory.Interface
{
    public interface IUIFactory
    {
        public List<IConcreteUI> CreateUIListByPageName(string PageName);
    }
}
