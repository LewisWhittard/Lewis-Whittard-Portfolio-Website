using SEO.Model.Alt;

namespace SEOTests.Model
{
    public class AltCtor
    {
        [Theory]
        [InlineData("SuperClassGUID", "Value", 1, false, false)]
        [InlineData("SuperClassGUID", "Value", 2, true, false)]
        [InlineData("SuperClassGUID", "Value", 3, false, true)]
        [InlineData("SuperClassGUID", "Value", 4, true, true)]
        public void MetaData_Constructor_SetsPropertiesCorrectly(string superClassGUID, string value, int id, bool deleted, bool inactive)
        {
            //arrange, Act
            AltData altData = new AltData(superClassGUID, value, id, deleted, inactive);

            // Assert
            Assert.Equal(superClassGUID, altData.SuperClassGUID);
            Assert.Equal(null, altData.UIConcreteType);
            Assert.Equal(value, altData.Value);
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
            Assert.Equal(null, altData.DisplayOrder);
            Assert.Equal(null, altData.Value);
            Assert.Equal(null, altData.GUID);
            Assert.Equal(0, altData.Id);
            Assert.Equal(false, altData.Deleted);
            Assert.Equal(false, altData.Inactive);
        }
    }

}
