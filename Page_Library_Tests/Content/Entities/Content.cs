using Page_Library.Content.Entities.Content.DTO;

namespace Page_Library_Tests.Content.Entities
{
    public class Content
    {
        [Fact]
        public void Content_Ctor_Correctly()
        {
            // Arrange
            var contentDTO = new contentDTO
            {
                ID = 1,
                Name = "Test Name",
                Path = "/test/path.jpg",
                Alt = "Test Alt"
            };

            // Act
            var content = new Page_Library.Content.Entities.Content.Content(contentDTO);

            // Assert
            Assert.Equal(contentDTO.ID, content.ID);
            Assert.Equal(contentDTO.Name, content.Name);
            Assert.Equal(contentDTO.Path, content.Path);
            Assert.Equal(contentDTO.Alt, content.Alt);
        }
    }
}
