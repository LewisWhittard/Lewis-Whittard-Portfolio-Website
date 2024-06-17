using Infrastructure.Models.Data.Shared.Image;

namespace UIFactory.Factory.Concrete.InformationBlock
{
    public class InformationBlock
    {
        public Infrastructure.Models.Data.InformationBlock.InfomatonBlock InformationBlockData { get; private set; }
        public List<SEO.Models.JsonLD.JsonLDData>? JsonLDData { get; private set; }
        public List<Heading>? Headings { get; private set; }
        public List<Paragraph>? Paragraphs { get; private set; }
        public List<Image> images { get; private set; }

        private readonly Infrastructure.Models.Data.InformationBlock.InfomatonBlock _informationBlockDatas;
        private readonly SEO.Service.JsonLDService.JsonLDService _jsonLDService;


        public InformationBlock(Infrastructure.Models.Data.InformationBlock.InfomatonBlock informationBlockDatas, SEO.Service.JsonLDService.JsonLDService jsonLDService)
        {
            _informationBlockDatas = informationBlockDatas;
            InformationBlockData = _informationBlockDatas;
            _jsonLDService = jsonLDService;
            SetJsonLD();
        }

        public void SetJsonLD()
        {
            if (InformationBlockData != null)
            {
                JsonLDData = _jsonLDService.GetBySuperClassGUID(InformationBlockData.GUID, false);
            }
            else
            {
                JsonLDData = null;
            }
        }

        public void SetHeadings()
        {
            if (InformationBlockData != null)
            {
                Headings = new List<Heading>();
                foreach (var heading in InformationBlockData.Headings)
                {
                    Headings.Add(new Heading(heading));
                }
            }
            else
            {
                Headings = null;
            }
        }

        public void SetParagraphs()
        {
            if (InformationBlockData != null)
            {
                Paragraphs = new List<Paragraph>();
                foreach (var paragraph in InformationBlockData.Paragraphs)
                {
                    Paragraphs.Add(new Paragraph(paragraph));
                }
            }
            else
            {
                Paragraphs = null;
            }
        }
    }
}