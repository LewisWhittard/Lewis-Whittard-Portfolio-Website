using Infrastructure.Models.Data.InformationBlock;

namespace UIFactoryTests.Concrete
{
    public class ParagraphTests
    {
        private List<Paragraph> _paragraphs;

        //setup
        public void SetUp()
        {
            _paragraphs = new List<Paragraph>();
            _paragraphs.Add(new Paragraph("Paragraph",0,0,false,false,0,"ParagraphUIId0"));
            _paragraphs.Add(new Paragraph("Paragraph", 1, 1, false, false, 1, "ParagraphUIId1"));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Paragraph_Ctor(int Id)
        {
            //Arrange
            SetUp();
            var paragraph = _paragraphs.Where(x => x.Id == Id).FirstOrDefault();

            //Act
            var paragraphConcrete = new UIFactory.Factory.Concrete.InformationBlock.Paragraph(paragraph);

            //Assert
            Assert.Equal(paragraph, paragraphConcrete.ParagraphData);
            Assert.Equal(paragraph.DisplayOrder, paragraphConcrete.DisplayOrder);
            Assert.Equal(paragraph.UIConcreteType, paragraphConcrete.UIConcreteType);

            TearDown();
        }

        public void TearDown()
        {
            _paragraphs = null;
        }
    }
}
