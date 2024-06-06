using Infrastructure.Models.Data.Interface;

namespace InfrastructureTests.Ctor
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
            Assert.Null(head.GUID);
            Assert.False(head.Deleted);
            Assert.False(head.Inactive);
            Assert.Equal(UIConcrete.Head, head.UIConcreteType);
            Assert.Null(head.Title);
            Assert.Equal(0, head.PageId);
        }

        [Theory]
        [InlineData(1, true, true, "Title1", 3)]
        [InlineData(2, false, true, "Title2", 4)]
        [InlineData(3, true, false, "Title3", 5)]
        [InlineData(4, false, false, "Title4", 6)]
        public void Head_Constructor_WithParameters(int id, bool deleted, bool inactive, string title, int pageId)
        {
            // Arrange and Act
            Infrastructure.Models.Data.Head.Head head = new Infrastructure.Models.Data.Head.Head(id, deleted, inactive, title, pageId);

            // Assert
            Assert.Equal(id, head.Id);
            Assert.Null(head.DisplayOrder);
            Assert.Null(head.GUID);
            Assert.Equal(deleted, head.Deleted);
            Assert.Equal(inactive, head.Inactive);
            Assert.Equal(UIConcrete.Head, head.UIConcreteType);
            Assert.Equal(title, head.Title);
            Assert.Equal(pageId, head.PageId);
        }


    }
}
