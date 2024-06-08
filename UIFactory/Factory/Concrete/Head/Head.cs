using SEO.Models.JsonLD;
using SEO.Models.Meta.Interface;
using SEO.Service.JsonLDService;
using SEO.Service.MetaService;
using UIFactory.Factory.Concrete.Interface;

namespace UIFactory.Factory.Concrete.Head
{
    public class Head : Interface.IHead, IConcrete
    {
        public Infrastructure.Models.Data.Head.Head HeadData { get; private set; }
        public List<MetaData>? MetaDatas { get; private set; }
        public List<JsonLDData>? jsonLDDatas { get; private set; }

        private readonly Infrastructure.Models.Data.Head.Head _head;
        private readonly MetaService? _metaService;
        private readonly JsonLDService? _jsonLDService;

        public Head(Infrastructure.Models.Data.Head.Head head, MetaService? metaService, JsonLDService? jsonLDService)
        {
            _head = head;
            _metaService = metaService;
            _jsonLDService = jsonLDService;
            SetMetaData();
            SetJsonLDData();
        }

        private void SetMetaData()
        {
            if (_metaService != null)
            {
                MetaDatas = _metaService.GetByPageId(HeadData.PageId, false);
            }
            else
            {
                MetaDatas = null;
            }
        }

        private void SetJsonLDData()
        {
            if (_jsonLDService != null)
            {
                jsonLDDatas = _jsonLDService.GetBySuperClassGUID(_head.GUID,false);
            }
            else
            {
                jsonLDDatas = null;
            }
        }



    }
}
