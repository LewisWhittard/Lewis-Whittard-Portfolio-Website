using SEO.Model.Alt;

namespace SEOTests.Model
{
    public class AltCtor
    {
        [Theory]
        [InlineData("SuperClassUIID", "Value", 1, false, false)]
        [InlineData("SuperClassUIID", "Value", 2, true, false)]
        [InlineData("SuperClassUIID", "Value", 3, false, true)]
        [InlineData("SuperClassUIID", "Value", 4, true, true)]
        public void MetaData_Constructor_SetsPropertiesCorrectly(string superClassUIID, string value, int id, bool deleted, bool inactive)
        {
            //arrange, Act
            AltData altData = new AltData(superClassUIID, value, id, deleted, inactive);

            // Assert
            Assert.Equal(superClassUIID, altData.SuperClassUIID);
            Assert.Equal(null, altData.UIConcreteType);
            Assert.Equal(value, altData.Value);
            Assert.Equal(id, altData.Id);
            Assert.Equal(deleted, altData.Deleted);
            Assert.Equal(inactive, altData.Inactive);
            Assert.Null(altData.DisplayOrder);
            Assert.Null(altData.UIID);
        }

        [Fact]
        public void MetaData_Constructor_NoParameters()
        {
            //arrange, Act
            AltData altData = new AltData();

            // Assert
            Assert.Equal(null, altData.SuperClassUIID);
            Assert.Equal(null, altData.UIConcreteType);
            Assert.Equal(null, altData.DisplayOrder);
            Assert.Equal(null, altData.Value);
            Assert.Equal(null, altData.UIID);
            Assert.Equal(0, altData.Id);
            Assert.Equal(false, altData.Deleted);
            Assert.Equal(false, altData.Inactive);
        }
    }

}
