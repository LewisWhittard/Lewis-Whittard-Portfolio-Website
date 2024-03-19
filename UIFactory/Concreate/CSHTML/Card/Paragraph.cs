using UIFactory.Concreate.CSHTML.Card.Interfaces;

namespace UIFactory.Concreate.CSHTML.Card
{
    public class Paragraph : IParagraph
    {
        public string Text { get; set; }
        public int Id { get; set; }

        public Paragraph(Infrastructure.Models.Data.Card.Paragraph paragraph)
        {
            Text = paragraph.Text;
            Id = paragraph.Id;
        }
    }
}
