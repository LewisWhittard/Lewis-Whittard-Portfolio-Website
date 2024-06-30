using SEO.Model.JsonLD;
using SEOTests.Service;

namespace SEOTests.Model
{
    public class JsonLDCtor
    {

        [Theory]
        [InlineData("UIId1", 1, false, false, null)]
        [InlineData("UIId2", 2, true, false, null)]
        [InlineData("UIId3", 3, false, true, null)]
        [InlineData("UIId4", 4, true, true, null)]
        [InlineData("UIId5", 5, false, true, 10)]

        // Add more test cases as needed
        public void JsonLDData_Constructor_SetsPropertiesCorrectly(
        string uIId, int id, bool deleted, bool inactive, int? pageId)
        {
            // Arrange, Act
            var jsonLDData = new JsonLDData(uIId, id, deleted, inactive, pageId);

            // Assert
            Assert.Equal(uIId, jsonLDData.UIId);
            Assert.Equal(null, jsonLDData.UIConcreteType);
            Assert.Equal(id, jsonLDData.Id);
            Assert.Equal(deleted, jsonLDData.Deleted);
            Assert.Equal(inactive, jsonLDData.Inactive);
            Assert.Equal(pageId, jsonLDData.PageId);
            Assert.Null(jsonLDData.DisplayOrder);
            Assert.Null(jsonLDData.UIID);
        }

        [Fact]
        public void JsonLDData_Constructor_NoParameters()
        {
            // Arrange, Act
            var jsonLDData = new JsonLDData();

            // Assert
            Assert.Equal(null, jsonLDData.UIId);
            Assert.Equal(null, jsonLDData.UIConcreteType);
            Assert.Equal(0, jsonLDData.Id);
            Assert.Equal(null, jsonLDData.DisplayOrder);
            Assert.Equal(null, jsonLDData.UIID);
            Assert.Equal(false, jsonLDData.Deleted);
            Assert.Equal(false, jsonLDData.Inactive);
            Assert.Equal(null, jsonLDData.PageId);
        }
    }
}