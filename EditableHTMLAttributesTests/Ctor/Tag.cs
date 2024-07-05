using EditableHTMLAttributes.Model.Interface;

namespace EditableHTMLAttributesTests.Ctor
{
    public class Tag
    {
        [Theory]
        [InlineData(0, TagType.Article, false, false, "Frist")]
        [InlineData(1, TagType.Section, false, false, "Second")]
        [InlineData(2, TagType.Div, true, false, "Non")]
        [InlineData(3, TagType.Article, false, true, "IncludeInactive")]
        [InlineData(4, TagType.Article, false, false, "ExcludeInactive")]
        [InlineData(4, TagType.Article, false, false, null)]
        public void Tag_Ctor_WithParameters(int id, TagType tagType, bool deleted, bool inactive, string uIId)
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
            Assert.True(tag.UIId == null);
        }
    }
}
