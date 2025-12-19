using Page_Library.Content.Repository;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Factory;
using Page_Library.Page.Repository;
using Page_Library.Page.Service;

namespace Page_Library_Tests.Page.Service
{
    public class PageServiceIntergrationTest
    {
        [Theory]
        [InlineData("0",2)]
        [InlineData("2",3)]
        public void PageService_GetPageById_Correctly(string id, int contentBlockCount)
        {
            var PagePath = Path.Combine(AppContext.BaseDirectory, "TestData", "Page", "Page.json");
            JsonPageRepository PageRepository = new JsonPageRepository(PagePath);
            ContentBlockFactory factory = new ContentBlockFactory();
            var ContentPath = Path.Combine(AppContext.BaseDirectory, "TestData", "Content", "content.json");
            JsonContentRepository contentRepository = new JsonContentRepository(ContentPath);

            PageService service = new PageService(PageRepository, factory, contentRepository);

            IPage result = service.GetPage(id);

            Assert.Equal(contentBlockCount, result.ContentBlocks.Count());
            Assert.Equal(id, result.ExternalId);
        }

        [Theory]
        [InlineData("","")]
        [InlineData(null,null)]
        public void PageService_SearchNull_correctly(string searchTerm, string category)
        {
            var PagePath = Path.Combine(AppContext.BaseDirectory, "TestData", "Page", "Page.json");
            JsonPageRepository PageRepository = new JsonPageRepository(PagePath);
            ContentBlockFactory factory = new ContentBlockFactory();
            var ContentPath = Path.Combine(AppContext.BaseDirectory, "TestData", "Content", "content.json");
            JsonContentRepository contentRepository = new JsonContentRepository(ContentPath);

            PageService service = new PageService(PageRepository, factory, contentRepository);
            var result = service.Search(searchTerm, category);

            Assert.True(result[0].ExternalId == "2");
            Assert.True(result[1].ExternalId == "1");
            Assert.True(result[2].ExternalId == "0");
            Assert.True(result.Count() == 3);


        }

        [Fact]
        public void PageService_CategoryIsCreativeWorks_correctly()
        {
            var PagePath = Path.Combine(AppContext.BaseDirectory, "TestData", "Page", "Page.json");
            JsonPageRepository PageRepository = new JsonPageRepository(PagePath);
            ContentBlockFactory factory = new ContentBlockFactory();
            var ContentPath = Path.Combine(AppContext.BaseDirectory, "TestData", "Content", "content.json");
            JsonContentRepository contentRepository = new JsonContentRepository(ContentPath);

            PageService service = new PageService(PageRepository, factory, contentRepository);
            var result = service.Search(null, "Creative Works");

            Assert.True(result[0].ExternalId == "2");
            Assert.True(result[1].ExternalId == "1");
            Assert.True(result.Count() == 2);
        }

        [Fact]
        public void PageService_CategoryIsSoftwareDevelopment_correctly()
        {
            var PagePath = Path.Combine(AppContext.BaseDirectory, "TestData", "Page", "Page.json");
            JsonPageRepository PageRepository = new JsonPageRepository(PagePath);
            ContentBlockFactory factory = new ContentBlockFactory();
            var ContentPath = Path.Combine(AppContext.BaseDirectory, "TestData", "Content", "content.json");
            JsonContentRepository contentRepository = new JsonContentRepository(ContentPath);

            PageService service = new PageService(PageRepository, factory, contentRepository);
            var result = service.Search(null, "Software Development");

            Assert.True(result[0].ExternalId == "1");
            Assert.True(result[1].ExternalId == "0");
            Assert.True(result.Count() == 2);
        }

        [Fact]
        public void PageService_SearchAll_correctly()
        {
            var PagePath = Path.Combine(AppContext.BaseDirectory, "TestData", "Page", "Page.json");
            JsonPageRepository PageRepository = new JsonPageRepository(PagePath);
            ContentBlockFactory factory = new ContentBlockFactory();
            var ContentPath = Path.Combine(AppContext.BaseDirectory, "TestData", "Content", "content.json");
            JsonContentRepository contentRepository = new JsonContentRepository(ContentPath);

            PageService service = new PageService(PageRepository, factory, contentRepository);
            var result = service.Search(null, "All");

            Assert.True(result[0].ExternalId == "2");
            Assert.True(result[1].ExternalId == "1");
            Assert.True(result[2].ExternalId == "0");
            Assert.True(result.Count() == 3);
        }


        [Theory]
        [InlineData("All")]
        [InlineData("Creative Works")]
        [InlineData("Software Development")]
        public void PageService_SearchForNothingValid_correctly(string category)
        {
            var PagePath = Path.Combine(AppContext.BaseDirectory, "TestData", "Page", "Page.json");
            JsonPageRepository PageRepository = new JsonPageRepository(PagePath);
            ContentBlockFactory factory = new ContentBlockFactory();
            var ContentPath = Path.Combine(AppContext.BaseDirectory, "TestData", "Content", "content.json");
            JsonContentRepository contentRepository = new JsonContentRepository(ContentPath);

            PageService service = new PageService(PageRepository, factory, contentRepository);
            var result = service.Search("Nothing to bring back", category);
            
            Assert.True(result.Count() == 0);
        }

    }
}
