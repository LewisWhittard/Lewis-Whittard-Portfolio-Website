using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD;

namespace SEOTests.Ctor
{
    public class JsonLDCtor
    {
        [Theory]
        [InlineData("superClassGUID", UIConcrete.Table, "page", 1, 10, "guid", false, false)]
        [InlineData(null, UIConcrete.InformationBlock, "page2", 2, null, "guid2", true, true)]
        [InlineData("superClassGUID", UIConcrete.Table, "page", 1, 10, "guid", true, false)]
        [InlineData(null, UIConcrete.InformationBlock, "page2", 2, null, "guid2", false, true)]
        // Add more test cases as needed
        public void JsonLDData_Constructor_SetsPropertiesCorrectly(
        string superClassGUID, UIConcrete uiConcreteType, string page,
        int id, int? displayOrder, string guid, bool deleted, bool inactive)
        {
            // Arrange, Act
            var jsonLDData = new JsonLDData(superClassGUID, uiConcreteType, page, id, displayOrder, guid, deleted, inactive);

            // Assert
            Assert.Equal(superClassGUID, jsonLDData.SuperClassGUID);
            Assert.Equal(uiConcreteType, jsonLDData.UIConcreteType);
            Assert.Equal(page, jsonLDData.Page);
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
            Assert.Equal(null, jsonLDData.Page);
            Assert.Equal(0, jsonLDData.Id);
            Assert.Equal(null, jsonLDData.DisplayOrder);
            Assert.Equal(null, jsonLDData.GUID);
            Assert.Equal(false, jsonLDData.Deleted);
            Assert.Equal(false, jsonLDData.Inactive);
        }
    }
}