using SEO.Models.JsonLD;

namespace SEOTests.Ctor
{
    public class JsonLDCtor
    {
        [Theory]
        [InlineData("superClassGUID", 1, 10, "guid", false, false)]
        [InlineData(null, 2, null, "guid2", true, true)]
        [InlineData("superClassGUID", 1, 10, "guid", true, false)]
        [InlineData(null, 2, null, "guid2", false, true)]
        // Add more test cases as needed
        public void JsonLDData_Constructor_SetsPropertiesCorrectly(
        string superClassGUID, int id, int? displayOrder, string guid, bool deleted, bool inactive)
        {
            // Arrange, Act
            var jsonLDData = new JsonLDData(superClassGUID, null, id, displayOrder, guid, deleted, inactive);

            // Assert
            Assert.Equal(superClassGUID, jsonLDData.SuperClassGUID);
            Assert.Equal(null, jsonLDData.UIConcreteType);
            Assert.Equal(id, jsonLDData.Id);
            Assert.Equal(displayOrder, jsonLDData.DisplayOrder);
            Assert.Equal(guid, jsonLDData.GUID);
            Assert.Equal(deleted, jsonLDData.Deleted);
            Assert.Equal(inactive, jsonLDData.Inactive);
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
        }
    }
}