namespace UIFactory.Strategy.Interface
{
    public class Strategy
    {
        public UI UIType { get; set; }

        public Strategy(UI uiType)
        {
            UIType = uiType;
        }
    }
}
