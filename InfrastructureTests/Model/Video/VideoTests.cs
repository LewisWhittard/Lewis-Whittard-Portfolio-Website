using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Video;

namespace InfrastructureTests.Model
{
    public class VideoTests
    {
        [Fact]
        public void Video_Constructor_NoParameters()
        {
            //arrange, act
            Video video = new Video();

            //assert
            Assert.Null(video.Source);
            Assert.Null(video.Title);
            Assert.Null(video.Description);
            Assert.Null(video.Navigation);
            Assert.Equal(0, video.Id);
            Assert.False(video.Deleted);
            Assert.False(video.Inactive);
            Assert.Null(video.DisplayOrder);
            Assert.Null(video.UIID);
            Assert.Equal(UIConcrete.Video, video.UIConcreteType);
            Assert.Equal(0, video.PageId);

        }

        [Theory]
        [InlineData("SampleSource1", "SampleTitle1", "SampleDescription1", "SampleNavigation1", 1, false, true, 10, "sample-uiid1",1)]
        [InlineData("SampleSource2", "SampleTitle2", "SampleDescription2", "SampleNavigation2", 2, true, false, 20, "sample-uiid2",2)]
        [InlineData("SampleSource3", "SampleTitle3", "SampleDescription3", "SampleNavigation3", 3, false, false, null, "sample-uiid3",3)]
        public void ParameterizedConstructor_ShouldInitializeAllProperties(string source, string title, string description, string navigation, int id, bool deleted, bool inactive, int? displayOrder, string uiid, int pageId)
        {
            // Act
            var video = new Video(source, title, description, navigation, id, deleted, inactive, displayOrder, uiid,pageId);

            // Assert
            Assert.Equal(source, video.Source);
            Assert.Equal(title, video.Title);
            Assert.Equal(description, video.Description);
            Assert.Equal(navigation, video.Navigation);
            Assert.Equal(id, video.Id);
            Assert.Equal(deleted, video.Deleted);
            Assert.Equal(inactive, video.Inactive);
            Assert.Equal(displayOrder, video.DisplayOrder);
            Assert.Equal(uiid, video.UIID);
            Assert.Equal(UIConcrete.Video, video.UIConcreteType);
            Assert.Equal(pageId, video.PageId);
        }
    }
}
