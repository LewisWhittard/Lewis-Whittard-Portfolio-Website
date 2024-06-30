using SEO.Model.JsonLD;
using SEOTests.Service;

namespace SEOTests.Model
{
    public class JsonLDCtor
    {

        [Theory]
        [InlineData("SuperClassUIID1", 1, false, false, null)]
        [InlineData("SuperClassUIID2", 2, true, false, null)]
        [InlineData("SuperClassUIID3", 3, false, true, null)]
        [InlineData("SuperClassUIID4", 4, true, true, null)]
        [InlineData("SuperClassUIID5", 5, false, true, 10)]

        // Add more test cases as needed
        public void JsonLDData_Constructor_SetsPropertiesCorrectly(
        string superClassUIID, int id, bool deleted, bool inactive, int? pageId)
        {
            // Arrange, Act
            var jsonLDData = new JsonLDData(superClassUIID, id, deleted, inactive, pageId);

            // Assert
            Assert.Equal(superClassUIID, jsonLDData.SuperClassUIID);
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
            Assert.Equal(null, jsonLDData.SuperClassUIID);
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