using SEO.Model.JsonLD;
using SEO.Model.Meta.Interface;
using SEO.Repository.JsonLDRepositoryRepository;
using SEO.Repository.MockMetaRepository;
using SEO.Service.JsonLDService;
using SEO.Service.MetaService;

namespace UIFactoryTests.Concrete
{
    public class HeadTests
    {
        private List<Infrastructure.Models.Data.Head.Head> _heads;
        private JsonLDService _jsonLDService;
        private MetaService _metaService;

        public void SetUp()
        {
            _jsonLDService = new JsonLDService(new MockJsonLDRepository());
            _metaService = new MetaService(new MockMetaRepository());
            _heads = new List<Infrastructure.Models.Data.Head.Head>();

            _heads.Add(new Infrastructure.Models.Data.Head.Head(0, false, false, "HeadTitle", 3, null));
            _heads.Add(new Infrastructure.Models.Data.Head.Head(1, false, false, "HeadTitle", 2, null));
            _heads.Add(new Infrastructure.Models.Data.Head.Head(2, false, false, "HeadTitle", 1, null));
            _heads.Add(new Infrastructure.Models.Data.Head.Head(3, false, false, "HeadTitle", 0, null));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Head_Ctor(int pageId)
        {
            SetUp();

            //Arrange
            var head = _heads.Where(x => x.PageId == pageId).FirstOrDefault();
            //act
            var headConcrete = new UIFactory.Factory.Concrete.Head.Head(head, _metaService, _jsonLDService);

            //Assert
            Assert.Equal(head, headConcrete.HeadData);
            Assert.Equal(head.DisplayOrder, headConcrete.DisplayOrder);
            Assert.Equal(head.UIConcreteType, headConcrete.UIConcreteType);

            switch (pageId)
            {
                case 0:
                    Assert.Equal(0,headConcrete.jsonLDDatas[0].PageId);
                    break;
                case 1:
                    Assert.Equal(1, headConcrete.jsonLDDatas[0].PageId);
                    break;
                case 2:
                    Assert.Equal(2, headConcrete.jsonLDDatas[0].PageId);
                    Assert.Equal(2, headConcrete.jsonLDDatas[1].PageId);
                    Assert.NotEqual(headConcrete.jsonLDDatas[0], headConcrete.jsonLDDatas[1]);
                    break;
                case 3:
                    Assert.Equal(0, headConcrete.jsonLDDatas.Count());
                    break;

            }

            switch (head.PageId)
            {
                case 0:
                    Assert.Equal(0, headConcrete.MetaDatas[0].PageId);
                    break;
                case 1:
                    Assert.Equal(1, headConcrete.MetaDatas[0].PageId);
                    break;
                case 2:
                    Assert.Equal(2, headConcrete.MetaDatas[0].PageId);
                    Assert.Equal(2, headConcrete.MetaDatas[1].PageId);
                    Assert.NotEqual(headConcrete.MetaDatas[0], headConcrete.MetaDatas[1]);
                    break;
                case 3:
                    Assert.Equal(0, headConcrete.MetaDatas.Count());
                    break;

            }



            TearDown();
        }


        private void TearDown()
        {
            _heads = null;
            _jsonLDService = null;
            _metaService = null;
        }
    }
}