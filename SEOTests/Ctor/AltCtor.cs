using Infrastructure.Models.Data.Interface;
using SEO.Models.Alt;

namespace SEOTests.Ctor
{
    public class AltCtor
    {
        [Theory]
        [InlineData("123456", UIConcrete.Video, "HomePage", 1, "SomeValue", "789012", 1001, false, true)]
        [InlineData("123456", null, "HomePage", 1, "SomeValue", "789012", 1001, true, false)]
        [InlineData("123456", UIConcrete.Video, "HomePage", 1, "SomeValue", "789012", 1001, true, true)]
        [InlineData("123456", null, "HomePage", 1, "SomeValue", "789012", 1001, false, false)]
        public void MetaData_Constructor_SetsPropertiesCorrectly(string superClassGUID, UIConcrete? uiConcreteType, string page, int? displayOrder, string value, string guid, int id, bool deleted, bool inactive)
        {
            //arrange, Act
            AltData altData = new AltData(superClassGUID, uiConcreteType, page, displayOrder, value, guid, id, deleted, inactive);

            // Assert
            Assert.Equal(superClassGUID, altData.SuperClassGUID);
            Assert.Equal(uiConcreteType, altData.UIConcreteType);
            Assert.Equal(page, altData.Page);
            Assert.Equal(displayOrder, altData.DisplayOrder);
            Assert.Equal(value, altData.Value);
            Assert.Equal(guid, altData.GUID);
            Assert.Equal(id, altData.Id);
            Assert.Equal(deleted, altData.Deleted);
            Assert.Equal(inactive, altData.Inactive);
        }

        [Fact]
        public void MetaData_Constructor_NoParameters()
        {
            //arrange, Act
            AltData altData = new AltData();

            // Assert
            Assert.Equal(null, altData.SuperClassGUID);
            Assert.Equal(null, altData.UIConcreteType);
            Assert.Equal(null, altData.Page);
            Assert.Equal(null, altData.DisplayOrder);
            Assert.Equal(null, altData.Value);
            Assert.Equal(null, altData.GUID);
            Assert.Equal(0, altData.Id);
            Assert.Equal(false, altData.Deleted);
            Assert.Equal(false, altData.Inactive);
        }
    }

}
