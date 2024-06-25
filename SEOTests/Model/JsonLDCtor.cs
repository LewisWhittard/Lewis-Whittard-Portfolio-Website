using SEO.Model.JsonLD;

namespace SEOTests.Model
{
    public class JsonLDCtor
    {

        [Theory]
        [InlineData("SuperClassGUID1", 1, false, false, null)]
        [InlineData("SuperClassGUID2", 2, true, false, null)]
        [InlineData("SuperClassGUID3", 3, false, true, null)]
        [InlineData("SuperClassGUID4", 4, true, true, null)]
        [InlineData("SuperClassGUID5", 5, false, true, 10)]

        // Add more test cases as needed
        public void JsonLDData_Constructor_SetsPropertiesCorrectly(
        string superClassGUID, int id, bool deleted, bool inactive, int? pageId)
        {
            // Arrange, Act
            var jsonLDData = new JsonLDData(superClassGUID, id, deleted, inactive, pageId);

            // Assert
            Assert.Equal(superClassGUID, jsonLDData.SuperClassGUID);
            Assert.Equal(null, jsonLDData.UIConcreteType);
            Assert.Equal(id, jsonLDData.Id);
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