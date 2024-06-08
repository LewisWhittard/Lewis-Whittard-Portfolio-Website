using SEO.Models.Meta.Interface;
using SEO.Service.MetaService;
using UIFactory.Factory.Concrete.Interface;

namespace UIFactory.Factory.Concrete.Head
{
    public class Head : Interface.IHead, IConcrete
    {
        public Infrastructure.Models.Data.Head.Head HeadData { get; private set; }
        public MetaData? MetaData { get; private set; }

        private readonly Infrastructure.Models.Data.Head.Head _head;
        private readonly MetaService? _metaService;

        public Head(Infrastructure.Models.Data.Head.Head head, MetaService? metaService)
        {
            _head = head;
            HeadData = _head;
            _metaService = metaService;
            SetMetaData();
        }

        private void SetMetaData()
        {
            if (_metaService != null)
            {
                MetaData = _metaService.GetByPageId(HeadData.PageId, false).FirstOrDefault();
            }
            else
            {
                MetaData = null;
            }
        }



    }
}
