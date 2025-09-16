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
        [InlineData(0)]
        [InlineData(1)]
        public void PageService_GetPageById_Correctly(int id)
        {
            var PagePath = Path.Combine(AppContext.BaseDirectory, "TestData", "Page", "Page.json");
            JsonPageRepository PageRepository = new JsonPageRepository(PagePath);
            ContentBlockFactory factory = new ContentBlockFactory();
            var ContentPath = Path.Combine(AppContext.BaseDirectory, "TestData", "Content", "content.json");
            JsonContentRepository contentRepository = new JsonContentRepository(ContentPath);

            PageService service = new PageService(PageRepository, factory, contentRepository);

            IPage result = service.GetPage(id);

            Assert.Equal(id, result.ExternalId);
        }


    }
}
