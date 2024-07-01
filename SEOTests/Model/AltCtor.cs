using SEO.Model.Alt;

namespace SEOTests.Model
{
    public class AltCtor
    {
        [Theory]
        [InlineData("UIId", "Value", 1, false, false)]
        [InlineData("UIId", "Value", 2, true, false)]
        [InlineData("UIId", "Value", 3, false, true)]
        [InlineData("UIId", "Value", 4, true, true)]
        public void MetaData_Constructor_SetsPropertiesCorrectly(string uIId, string value, int id, bool deleted, bool inactive)
        {
            //arrange, Act
            AltData altData = new AltData(uIId, value, id, deleted, inactive);

            // Assert
            Assert.Equal(uIId, altData.UIId);
            Assert.Equal(null, altData.UIConcreteType);
            Assert.Equal(value, altData.Value);
            Assert.Equal(id, altData.Id);
            Assert.Equal(deleted, altData.Deleted);
            Assert.Equal(inactive, altData.Inactive);
            Assert.Null(altData.DisplayOrder);
        }

        [Fact]
        public void MetaData_Constructor_NoParameters()
        {
            //arrange, Act
            AltData altData = new AltData();

            // Assert
            Assert.Equal(null, altData.UIId);
            Assert.Equal(null, altData.UIConcreteType);
            Assert.Equal(null, altData.DisplayOrder);
            Assert.Equal(null, altData.Value);
            Assert.Equal(0, altData.Id);
            Assert.Equal(false, altData.Deleted);
            Assert.Equal(false, altData.Inactive);
        }
    }

}
