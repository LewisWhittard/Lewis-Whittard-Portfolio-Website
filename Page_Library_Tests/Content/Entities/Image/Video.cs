using Page_Library.Content.Entities.Content.Base;
using Page_Library.Content.Entities.Content.DTO;

namespace Page_Library_Tests.Content.Entities.Image
{
    public class Video()
    {
        [Fact]
        public void Video_Ctor_Correctly()
        {
            // Arrange
            var contentDTO = new contentDTO
            {
                ID = 1,
                Name = "Test Name",
                Path = "/test/path.jpg",
                Description = "Test desc",
                ContentType = "Video"
            };

            // Act
            var video = new Page_Library.Content.Entities.Content.Video(contentDTO);

            // Assert
            Assert.Equal(contentDTO.ID, video.ID);
            Assert.Equal(contentDTO.Name, video.Name);
            Assert.Equal(contentDTO.Path, video.Path);
            Assert.Equal(contentDTO.Description, video.Description);
            Assert.Equal(contentDTO.ContentType, video.ContentType);
        }
    }
}
