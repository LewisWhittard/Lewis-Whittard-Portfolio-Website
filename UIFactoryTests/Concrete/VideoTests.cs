using Infrastructure.Models.Data.Video;
using SEO.Repository.JsonLDRepositoryRepository;
using SEO.Service.JsonLDService;

namespace UIFactoryTests.Concrete
{
    public class VideoTests
    {
        private JsonLDService _jsonLDService;
        private List<Video> Videos;

        //setup
        private void SetUp()
        {
            Videos = new List<Infrastructure.Models.Data.Video.Video>();
            MockJsonLDRepository mockJsonLDRepository = new MockJsonLDRepository();
            _jsonLDService = new JsonLDService(mockJsonLDRepository);
            Videos.Add(new Video("","","","",0,false,false,4,"First",0));
            Videos.Add(new Video("", "", "", "", 1, false, false, 3, "Second", 1));
            Videos.Add(new Video("", "", "", "", 2, false, false, 2, "Multiple", 2));
            Videos.Add(new Video("", "", "", "", 3, false, false, 3, null, 4));
            Videos.Add(new Video("", "", "", "", 4, false, false, 4, "Non", 4));
        }

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
                    Assert.NotEqual(videoConcrete.JsonLDDatas[0], videoConcrete.JsonLDDatas[1]);
                    break;
                case 3:
                    Assert.Equal(null, videoConcrete.JsonLDDatas[0].SuperClassGUID);
                    break;
                case 4:
                    Assert.Equal(0, videoConcrete.JsonLDDatas.Count());
                    break;

            }
            TearDown();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Video_CtorNullService_JsonLDData(int videoId)
        {
            SetUp();
            //Arrange
            var video = Videos.Where(x => x.Id == videoId).FirstOrDefault();
            //act
            var videoConcrete = new UIFactory.Factory.Concrete.Video.Video(video,null);

            //Assert
            switch (videoId)
            {
                case 0:
                    Assert.Null(videoConcrete.JsonLDDatas);
                    break;
                case 1:
                    Assert.Null(videoConcrete.JsonLDDatas);
                    break;
                case 2:
                    Assert.Null(videoConcrete.JsonLDDatas);
                    break;
                case 3:
                    Assert.Null(videoConcrete.JsonLDDatas);
                    break;
                case 4:
                    Assert.Null(videoConcrete.JsonLDDatas);
                    break;

            }
            TearDown();
        }


        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Video_Ctor(int videoId)
        {
            SetUp();
            //Arrange
            var video = Videos.Where(x => x.Id == videoId).FirstOrDefault();
            //act
            var videoConcrete = new UIFactory.Factory.Concrete.Video.Video(video,_jsonLDService);

            //Assert
            Assert.Equal(video, videoConcrete.VideoData);
            Assert.Equal(video.DisplayOrder, videoConcrete.DisplayOrder);
            Assert.Equal(video.UIConcreteType, videoConcrete.UIConcreteType);

            switch (videoId)
            {
                case 0:
                    Assert.Equal("First", videoConcrete.JsonLDDatas[0].SuperClassGUID);
                    break;
                case 1:
                    Assert.Equal("Second", videoConcrete.JsonLDDatas[0].SuperClassGUID);
                    break;
            }
            TearDown();
        }

        //TearDown
        private void TearDown()
        {
            Videos = null;
            _jsonLDService = null;
        }

    }
}
