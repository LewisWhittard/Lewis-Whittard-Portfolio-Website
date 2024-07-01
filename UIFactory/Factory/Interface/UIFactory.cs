using UIFactory.Factory.Concrete.Interface;

namespace UIFactory.Factory.Interface
{
    public interface IUIFactory
    {
        public List<IConcreteUI> CreateConcreteUIListByPageName(string PageName);
    }
}
