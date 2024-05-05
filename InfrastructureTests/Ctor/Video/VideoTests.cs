using Infrastructure.Models.Data.Interface;

namespace InfrastructureTests.Ctor
{
    public class VideoTests
    {
        [Fact]
        public void Video_Constructor_NoParameters()
        {
            //arrange, act
            Infrastructure.Models.Data.Video.Video video = new Infrastructure.Models.Data.Video.Video();

            //assert
            Assert.Null(video.Source);
            Assert.Null(video.Title);
            Assert.Null(video.Description);
            Assert.Null(video.Navigation);
            Assert.Equal(0, video.Id);
            Assert.False(video.Deleted);
            Assert.False(video.Inactive);
            Assert.Null(video.DisplayOrder);
            Assert.Null(video.GUID);
            Assert.Equal(UIConcrete.Video, video.UIConcreteType);

        }
    }
}
