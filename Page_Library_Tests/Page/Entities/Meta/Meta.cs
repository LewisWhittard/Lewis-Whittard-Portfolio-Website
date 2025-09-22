using Page_Library.Page.Entities.MetaData.Base;
using Page_Library.Page.Entities.MetaData.DTO;

namespace Page_Library_Tests.Page.Entities.Meta
{
    public class Meta
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties_FromDTO()
        {
            // Arrange
            var dto = new MetaDTO
            {
                MetaTitle = "Test Title",
                MetaDescription = "Test Description",
                MetaKeywords = new List<string> { "keyword1", "keyword2" },
                MetaImageId = 101
            };

            // Act
            var meta = new MetaBase(dto);

            // Assert
            Assert.Equal(dto.MetaTitle, meta.MetaTitle);
            Assert.Equal(dto.MetaDescription, meta.MetaDescription);
            Assert.Equal(dto.MetaKeywords, meta.MetaKeywords);
            Assert.Equal(dto.MetaImageId, meta.MetaImageId);
        }
    }
}