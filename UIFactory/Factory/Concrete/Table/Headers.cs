using UIFactory.Factory.Concrete.Table.Interface;

namespace UIFactory.Factory.Concrete.Table
{
    public class Headers : IHeader
    {
        public Infrastructure.Models.Data.Table.Header HeaderData { get; private set; }
    }
}
