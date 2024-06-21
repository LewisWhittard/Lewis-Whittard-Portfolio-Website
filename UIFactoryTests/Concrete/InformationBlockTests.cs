using Infrastructure.Models.Data.InformationBlock;

namespace UIFactoryTests.Concrete
{

    public class InformationBlockTests
    {
        private List<InformationBlockTests> _informationBlocks;


        public void SetUp()
        {
            var paragraphs0 = new List<Paragraph>();
            paragraphs0.Add(new Paragraph("Paragraph00", 0, 0, false, false, 0, "ParagraphGUID00"));
            paragraphs0.Add(new Paragraph("Paragraph01", 1, 0, false, false, 0, "ParagraphGUID01"));

            var paragraphs1 = new List<Paragraph>();
            paragraphs1.Add(new Paragraph("Paragraph10", 0, 1, false, false, 1, "ParagraphGUID10"));
            paragraphs1.Add(new Paragraph("Paragraph11", 1, 1, false, false, 1, "ParagraphGUID11"));

            var paragraphs2 = new List<Paragraph>();
            paragraphs2.Add(new Paragraph("Paragraph20", 0, 2, false, false, 2, "ParagraphGUID20"));
            paragraphs2.Add(new Paragraph("Paragraph21", 1, 2, false, false, 2, "ParagraphGUID21"));

            var paragraphs3 = new List<Paragraph>();
            paragraphs3.Add(new Paragraph("Paragraph30", 0, 3, false, false, 3, "ParagraphGUID30"));
            paragraphs3.Add(new Paragraph("Paragraph31", 1, 3, false, false, 3, "ParagraphGUID31"));

            var paragraphs4 = new List<Paragraph>();
            paragraphs4.Add(new Paragraph("Paragraph40", 0, 4, false, false, 4, "ParagraphGUID40"));
            paragraphs4.Add(new Paragraph("Paragraph41", 1, 4, false, false, 4, "ParagraphGUID41"));

            var headings0 = new List<Heading>();
            headings0.Add(new Heading(0, false, false, "Heading00Text", 0, 0, "Heading00GUID", 0));
            headings0.Add(new Heading(1, false, false, "Heading01Text", 1, 0, "Heading01GUID", 1));

            var headings1 = new List<Heading>();
            headings1.Add(new Heading(0, false, false, "Heading10Text", 0, 1, "Heading10GUID", 0));
            headings1.Add(new Heading(1, false, false, "Heading11Text", 1, 1, "Heading11GUID", 1));

            var headings2 = new List<Heading>();
            headings2.Add(new Heading(0, false, false, "Heading20Text", 0, 2, "Heading20GUID", 0));
            headings2.Add(new Heading(1, false, false, "Heading21Text", 1, 2, "Heading21GUID", 1));

            var headings3 = new List<Heading>();
            headings3.Add(new Heading(0, false, false, "Heading30Text", 0, 3, "Heading30GUID", 0));
            headings3.Add(new Heading(1, false, false, "Heading31Text", 1, 3, "Heading31GUID", 1));

            var headings4 = new List<Heading>();
            headings4.Add(new Heading(0, false, false, "Heading40Text", 0, 4, "Heading40GUID", 0));
            headings4.Add(new Heading(1, false, false, "Heading41Text", 1, 4, "Heading41GUID", 1));

            var imageDatas0 = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas0.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 0, false, false, "Image00GUID", null, 0, null));
            imageDatas0.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 1, 1, false, false, "Image01GUID", null, 0, null));

            var imageDatas1 = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas1.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 2, false, false, "Image10GUID", null, 1, null));
            imageDatas1.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 1, 3, false, false, "Image11GUID", null, 1, null));

            var imageDatas2 = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas2.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 4, false, false, "Image20GUID", null, 2, null));
            imageDatas2.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 1, 5, false, false, "Image21GUID", null, 2, null));

            var imageDatas3 = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas3.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 6, false, false, "Image30GUID", null, 3, null));
            imageDatas3.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 1, 7, false, false, "Image31GUID", null, 3, null));

            var imageDatas4 = new List<Infrastructure.Models.Data.Shared.Image.Image>();
            imageDatas4.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 0, 8, false, false, "Image40GUID", null, 4, null));
            imageDatas4.Add(new Infrastructure.Models.Data.Shared.Image.Image("", 1, 9, false, false, "Image41GUID", null, 4, null));
            
            InfomatonBlock infomatonBlock0 = new InfomatonBlock(0,false,false,imageDatas0,paragraphs0,headings0,4,"First",0);
            InfomatonBlock infomatonBlock1 = new InfomatonBlock(1, false, false, imageDatas1, paragraphs1, headings1, 3, "Second", 1);
            InfomatonBlock infomatonBlock2 = new InfomatonBlock(2, false, false, imageDatas2, paragraphs2, headings2, 2, "Non", 2);
            InfomatonBlock infomatonBlock3 = new InfomatonBlock(3, false, false, imageDatas3, paragraphs3, headings3, 1, null, 3);
            InfomatonBlock infomatonBlock4 = new InfomatonBlock(4, false, false, imageDatas4, paragraphs4, headings4, 0, "Multiple", 4);

        }
    }
}
