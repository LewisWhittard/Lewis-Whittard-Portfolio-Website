using Infrastructure.Models.Data.Interface;
using SEO.Models.Meta.Interface;

namespace SEOTests.Ctor
{
    public class MetaCtorTests
    {
        [Theory]
        [InlineData(1, Name.OGTitle, "Lorem ipsum", "12345678-1234-1234-1234-123456789abc", "UTF-8", false, false, UIConcrete.Table, 2, "HomePage")]
        [InlineData(2, Name.Author, "Dolor sit amet", "87654321-4321-4321-4321-987654321cba", null, true, true, null, null, "AboutPage")]
        public void MetaData_Constructor_SetsPropertiesCorrectly(int id, Name name, string content, string guid, string charset, bool deleted, bool inactive, UIConcrete? uiConcreteType, int? displayOrder, string pageName)
        {
            // Arrange, Act
            MetaData metaData = new MetaData(id, name, content, guid, charset, deleted, inactive, uiConcreteType, displayOrder, pageName);


            // Assert
            Assert.Equal(id, metaData.Id);
            Assert.Equal(name, metaData.Name);
            Assert.Equal(content, metaData.Content);
            Assert.Equal(guid, metaData.GUID);
            Assert.Equal(charset, metaData.Charset);
            Assert.Equal(deleted, metaData.Deleted);
            Assert.Equal(inactive, metaData.Inactive);
            Assert.Equal(uiConcreteType, metaData.UIConcreteType);
            Assert.Equal(displayOrder, metaData.DisplayOrder);
            Assert.Equal(pageName, metaData.PageName);
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
            Assert.Equal(null, metaData.PageName);
        }
    }
}
