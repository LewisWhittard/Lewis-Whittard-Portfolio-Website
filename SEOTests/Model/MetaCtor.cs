using SEO.Model.Meta.Interface;

namespace SEOTests.Model
{
    public class MetaCtor
    {
        [Theory]
        [InlineData(0, Name.Viewport, "content1", "charset1", false, false, 0)]
        [InlineData(1, Name.Description, "content2", "charset2", true, false, 1)]
        [InlineData(2, Name.Author, "content3", "charset3", false, true, 2)]
        [InlineData(3, Name.OGTitle, "content4", "charset4", true, true, 3)]
        public void MetaData_Constructor_SetsPropertiesCorrectly(int id, Name name, string content, string charset, bool deleted, bool inactive, int PageId)
        {
            // Arrange, Act
            MetaData metaData = new MetaData(id, name, content, charset, deleted, inactive, PageId);
            // Assert
            Assert.Equal(id, metaData.Id);
            Assert.Equal(name, metaData.Name);
            Assert.Equal(content, metaData.Content);
            Assert.Equal(charset, metaData.Charset);
            Assert.Equal(deleted, metaData.Deleted);
            Assert.Equal(inactive, metaData.Inactive);
            Assert.Equal(null,metaData.UIConcreteType);
            Assert.Equal(PageId, metaData.PageId);
        }

        [Fact]
        public void MetaData_Constructor_NoParameters()
        {
            // Arrange, Act
            MetaData metaData = new MetaData();
            // Assert
            Assert.Equal(0, metaData.Id);
            Assert.Equal(Name.Viewport, metaData.Name);
            Assert.Equal(null, metaData.Content);
            Assert.Equal(null, metaData.GUID);
            Assert.Equal(null, metaData.Charset);
            Assert.Equal(false, metaData.Deleted);
            Assert.Equal(false, metaData.Inactive);
            Assert.Equal(null, metaData.UIConcreteType);
            Assert.Equal(null, metaData.DisplayOrder);
            Assert.Equal(0, metaData.PageId);
        }
    }
}
