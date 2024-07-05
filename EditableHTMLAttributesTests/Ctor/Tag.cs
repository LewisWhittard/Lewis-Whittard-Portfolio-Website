using EditableHTMLAttributes.Model.Interface;

namespace EditableHTMLAttributesTests.Ctor
{
    public class Tag
    {
        [Theory]
        [InlineData(1, TagType.Section, true, false, 4)]
        [InlineData(2, TagType.Article, false, true, 3)]
        [InlineData(3, TagType.Div, true, true, 2)]
        [InlineData(4, null, false, false, 1)]
        public void Tag_Ctor_WithParameters(int id, TagType tagType, bool deleted, bool inactive, int uIId)
        {
            var tag = new EditableHTMLAttributes.Model.Tag(id, tagType, deleted, inactive, uIId);

            Assert.True(tag.Id == id);
            Assert.True(tag.Type == tagType);
            Assert.True(tag.Deleted == deleted);
            Assert.True(tag.Inactive == inactive);
            Assert.True(tag.UIId == uIId);
        }

        [Fact]
        public void Tag_Ctror_NoParameters()
        {
            var tag = new EditableHTMLAttributes.Model.Tag();

            Assert.True(tag.Id == 0);
            Assert.True(tag.Type == 0);
            Assert.True(tag.Deleted == false);
            Assert.True(tag.Inactive == false);
            Assert.True(tag.UIId == 0);
        }
    }
}
