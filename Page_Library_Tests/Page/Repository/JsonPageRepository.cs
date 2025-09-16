namespace Page_Library_Tests.Page.Repository
{
    public class JsonPageRepository
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void GetPage_ByID_ReturnsCorrectly(int id)
        {
            // Arrange
            var jsonPath = Path.Combine(AppContext.BaseDirectory, "TestData", "Page", "Page.json");
            var repo = new Page_Library.Page.Repository.JsonPageRepository(jsonPath);

            // Act
            var page = repo.GetPage(id);

            // Assert
            Assert.Equal(id, page.ExternalId);
        }
    }
}
