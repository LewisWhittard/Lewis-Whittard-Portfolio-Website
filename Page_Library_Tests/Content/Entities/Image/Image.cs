using Page_Library.Content.Entities.Content.DTO;

namespace Page_Library_Tests.Content.Entities.Image
{
    public class Image
    {
        [Fact]
        public void Image_Ctor_Correctly()
        {
            // Arrange
            var contentDTO = new contentDTO
            {
                ID = 1,
                Name = "Test Name",
                Path = "/test/path.jpg",
                Alt = "Test Alt",
                Type = "Image"
            };

            // Act
            var image = new Page_Library.Content.Entities.Content.Image(contentDTO);

            // Assert
            Assert.Equal(contentDTO.ID, image.ID);
            Assert.Equal(contentDTO.Name, image.Name);
            Assert.Equal(contentDTO.Path, image.Path);
            Assert.Equal(contentDTO.Alt, image.Alt);
            Assert.Equal(contentDTO.Type, image.Type);
        }
    }
}
