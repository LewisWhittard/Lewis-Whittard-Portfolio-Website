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

            _heads.Add(new Infrastructure.Models.Data.Head.Head(0, false, false, "HeadTitle", 4, "First"));
            _heads.Add(new Infrastructure.Models.Data.Head.Head(1, false, false, "HeadTitle", 3, "Second"));
            _heads.Add(new Infrastructure.Models.Data.Head.Head(2, false, false, "HeadTitle", 2, "Non"));
            _heads.Add(new Infrastructure.Models.Data.Head.Head(3, false, false, "HeadTitle", 1, null));
            _heads.Add(new Infrastructure.Models.Data.Head.Head(4, false, false, "HeadTitle", 0, "Multiple"));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Head_Ctor(int headId)
        {
            SetUp();

            //Arrange
            var head = _heads.Where(x => x.Id == headId).FirstOrDefault();
            //act
            var headConcrete = new UIFactory.Factory.Concrete.Head.Head(head, _metaService, _jsonLDService);

            //Assert
            Assert.Equal(head, headConcrete.HeadData);
            Assert.Equal(head.DisplayOrder, headConcrete.DisplayOrder);
            Assert.Equal(head.UIConcreteType, headConcrete.UIConcreteType);

            switch (headId)
            {
                case 0:
                    Assert.Equal("First", headConcrete.jsonLDDatas[0].SuperClassGUID);
                    break;
                case 1:
                    Assert.Equal("Second", headConcrete.jsonLDDatas[0].SuperClassGUID);
                    break;
                case 2:
                    Assert.Equal(0, headConcrete.jsonLDDatas.Count());
                    break;
                case 3:
                    Assert.Equal(0, headConcrete.jsonLDDatas.Count());
                    break;
                case 4:
                    Assert.Equal("Multiple", headConcrete.jsonLDDatas[0].SuperClassGUID);
                    Assert.Equal("Multiple", headConcrete.jsonLDDatas[1].SuperClassGUID);
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