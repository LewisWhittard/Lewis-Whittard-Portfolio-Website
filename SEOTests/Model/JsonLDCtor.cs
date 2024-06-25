using SEO.Model.JsonLD;

namespace SEOTests.Model
{
    public class JsonLDCtor
    {
        [Theory]
        [InlineData("superClassGUID", 1, 10, "guid", false, false,11)]
        [InlineData(null, 2, null, "guid2", true, true, 13)]
        [InlineData("superClassGUID", 1, 10, "guid", true, false, 14)]
        [InlineData(null, 2, null, "guid2", false, true, null)]
        // Add more test cases as needed
        public void JsonLDData_Constructor_SetsPropertiesCorrectly(
        string superClassGUID, int id, int? displayOrder, string guid, bool deleted, bool inactive, int? pageId)
        {
            // Arrange, Act
            var jsonLDData = new JsonLDData(superClassGUID, id, displayOrder, guid, deleted, inactive, pageId);

            // Assert
            Assert.Equal(superClassGUID, jsonLDData.SuperClassGUID);
            Assert.Equal(null, jsonLDData.UIConcreteType);
            Assert.Equal(id, jsonLDData.Id);
            Assert.Equal(displayOrder, jsonLDData.DisplayOrder);
            Assert.Equal(guid, jsonLDData.GUID);
            Assert.Equal(deleted, jsonLDData.Deleted);
            Assert.Equal(inactive, jsonLDData.Inactive);
            Assert.Equal(pageId, jsonLDData.PageId);
        }

        [Fact]
        public void JsonLDData_Constructor_NoParameters()
        {
            // Arrange, Act
            var jsonLDData = new JsonLDData();

            // Assert
            Assert.Equal(null, jsonLDData.SuperClassGUID);
            Assert.Equal(null, jsonLDData.UIConcreteType);
            Assert.Equal(0, jsonLDData.Id);
            Assert.Equal(null, jsonLDData.DisplayOrder);
            Assert.Equal(null, jsonLDData.GUID);
            Assert.Equal(false, jsonLDData.Deleted);
            Assert.Equal(false, jsonLDData.Inactive);
            Assert.Equal(null, jsonLDData.PageId);
        }
    }
}