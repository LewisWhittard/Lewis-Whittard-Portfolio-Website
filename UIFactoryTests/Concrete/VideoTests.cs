using Infrastructure.Models.Data.Video;
using SEO.Repository.AltRepository;
using SEO.Repository.JsonLDRepositoryRepository;
using SEO.Service.JsonLDService;

namespace UIFactoryTests.Concrete
{
    public class VideoTests
    {
        private JsonLDService _jsonLDService;
        private List<Infrastructure.Models.Data.Video.Video> Videos;

        //setup
        private void SetUp()
        {
            Videos = new List<Infrastructure.Models.Data.Video.Video>();
            MockJsonLDRepository mockJsonLDRepository = new MockJsonLDRepository();
            _jsonLDService = new JsonLDService(mockJsonLDRepository);
            Videos.Add(new Video("","","","",0,false,false,0,"First",0));
            Videos.Add(new Video("", "", "", "", 1, false, false, 1, "Second", 1));
            Videos.Add(new Video("", "", "", "", 2, false, false, 2, "Multiple", 2));
            Videos.Add(new Video("", "", "", "", 3, false, false, 3, "Non", 4));
            Videos.Add(new Video("", "", "", "", 4, false, false, 4, null, 4));
        }

        //Video_Ctor_JsonLDData
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Video_Ctor_JsonLDData(int videoId)
        {
            SetUp();

            //Arrange
            var video = Videos.Where(x => x.Id == videoId).FirstOrDefault();
            //act
            var videoConcrete = new UIFactory.Factory.Concrete.Video.Video(video, _jsonLDService);

            //Assert
            switch (videoId)
            {
                case 0:
                    Assert.Equal("First", videoConcrete.JsonLDDatas[0].SuperClassGUID);
                    break;
                case 1:
                    Assert.Equal("Second", videoConcrete.JsonLDDatas[0].SuperClassGUID);
                    break;
                case 2:
                    Assert.Equal("Multiple", videoConcrete.JsonLDDatas[0].SuperClassGUID);
                    Assert.Equal("Multiple", videoConcrete.JsonLDDatas[1].SuperClassGUID);
                    break;
                case 3:
                    Assert.Equal(0, videoConcrete.JsonLDDatas.Count());
                    break;
                case 4:
                    Assert.Equal(0, videoConcrete.JsonLDDatas.Count());
                    break;

            }
            TearDown();
        }

        //TearDown
        private void TearDown()
        {
            Videos = null;
        }

    }
}
