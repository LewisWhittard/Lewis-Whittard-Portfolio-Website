using Infrastructure.Models.Data.Interface;

namespace InfrastructureTests.Model
{
    public class HeadTests
    {
        [Fact]
        public void Head_Constructor_NoParameters()
        {
            // Arrange and Act
            Infrastructure.Models.Data.Head.Head head = new Infrastructure.Models.Data.Head.Head();

            // Assert
            Assert.Equal(0, head.Id);
            Assert.Null(head.DisplayOrder);
            Assert.Null(head.UIID);
            Assert.False(head.Deleted);
            Assert.False(head.Inactive);
            Assert.Equal(UIConcrete.Head, head.UIConcreteType);
            Assert.Null(head.Title);
            Assert.Equal(0, head.PageId);
        }

        [Theory]
        [InlineData(1, true, true, "Title1", 3,"uIIdHead1")]
        [InlineData(2, false, true, "Title2", 4, "uIIdHead2")]
        [InlineData(3, true, false, "Title3", 5, "uIIdHead3")]
        [InlineData(4, false, false, "Title4", 6, "uIIdHead4")]
        public void Head_Constructor_WithParameters(int id, bool deleted, bool inactive, string title, int pageId, string uIId)
        {
            // Arrange and Act
            Infrastructure.Models.Data.Head.Head head = new Infrastructure.Models.Data.Head.Head(id, deleted, inactive, title, pageId, uIId);

            // Assert
            Assert.Equal(id, head.Id);
            Assert.Null(head.DisplayOrder);
            Assert.Equal(uIId,head.UIID);
            Assert.Equal(deleted, head.Deleted);
            Assert.Equal(inactive, head.Inactive);
            Assert.Equal(UIConcrete.Head, head.UIConcreteType);
            Assert.Equal(title, head.Title);
            Assert.Equal(pageId, head.PageId);
        }


    }
}
