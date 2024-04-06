namespace UIFactory.Factory.Interface
{
    public interface IUIFactory
    {
        public List<IUI> CreateUIListByPageName(string PageName);
    }
}
