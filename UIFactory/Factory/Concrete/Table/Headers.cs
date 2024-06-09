using UIFactory.Factory.Concrete.Table.Interface;

namespace UIFactory.Factory.Concrete.Table
{
    internal class Headers : IHeader
    {
        public List<Infrastructure.Models.Data.Table.Header> HeaderDatas { get; private set; }

        private readonly List<Infrastructure.Models.Data.Table.Header> _headers;

        public Headers(List<Infrastructure.Models.Data.Table.Header> headers)
        {
            _headers = headers;
            HeaderDatas = _headers;
        }
    }
}
