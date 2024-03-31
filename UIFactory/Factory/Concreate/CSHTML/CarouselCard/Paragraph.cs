using UIFactory.Factory.Concreate.CSHTML.CarouselCard.Interfaces;

namespace UIFactory.Factory.Concreate.CSHTML.CarouselCard
{
    public class Paragraph : IParagraph
    {
        public string Text { get; set; }
        public int Id { get; set; }

        public Paragraph(Infrastructure.Models.Data.CarouselCard.Paragraph paragraph)
        {
            Text = paragraph.Text;
            Id = paragraph.Id;
        }
    }
}
