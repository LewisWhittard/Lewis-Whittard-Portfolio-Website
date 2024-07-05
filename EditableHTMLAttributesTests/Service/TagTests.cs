using EditableHTMLAttributes.Repository.Tag;
using EditableHTMLAttributes.Service.Tag;
using Infrastructure.Repository.Page;
using Infrastructure.Service.Page;
using System.Xml.Schema;

namespace EditableHTMLAttributesTests.Service
{
    public class TagTests
    {
        private TagService _tagService;

        public void SetUp()
        {
            MockTagRepository mockTagRepository = new MockTagRepository();
            _tagService = new TagService(mockTagRepository);
        }

        [Theory]
        [InlineData("First", false)]
        [InlineData("Second", false)]
        [InlineData("Non", false)]
        [InlineData("Deleted", false)]
        [InlineData("IncludeInactive", true)]
        [InlineData("ExcludeInactive", false)]
        public void GetByUIId(string uIId, bool includeInactive)
        {
            SetUp();

            var Result = _tagService.GetByUIId(uIId,includeInactive);

            // Assert
            if (uIId == "Non" || uIId == "Deleted" || uIId == "ExcludeInactive")
            {
                Assert.Null(Result);
            }
            else
            {
                Assert.Equal(uIId,Result.UIId);
            }

            TearDown();

        }


        public void TearDown()
        {
            _tagService = null;
        }

    }
}
