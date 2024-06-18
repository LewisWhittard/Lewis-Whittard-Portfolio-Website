using SEO.Service.AltService;
using UIFactory.Factory.Concrete.InformationBlock.Interface;
using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Concrete.Shared.Image;

namespace UIFactory.Factory.Concrete.InformationBlock
{
    public class InformationBlock : IInformationBlock, IConcreteUI
    {
        public Infrastructure.Models.Data.InformationBlock.InfomatonBlock InformationBlockData { get; private set; }
        public List<SEO.Model.JsonLD.JsonLDData>? JsonLDData { get; private set; }
        public List<Heading>? Headings { get; private set; }
        public List<Paragraph>? Paragraphs { get; private set; }
        public List<Image>? Images { get; private set; }

        private readonly Infrastructure.Models.Data.InformationBlock.InfomatonBlock _informationBlockDatas;
        private readonly SEO.Service.JsonLDService.JsonLDService _jsonLDService;
        private readonly AltService _altService;


        public InformationBlock(Infrastructure.Models.Data.InformationBlock.InfomatonBlock informationBlockDatas, SEO.Service.JsonLDService.JsonLDService jsonLDService, AltService altService)
        {
            _informationBlockDatas = informationBlockDatas;
            InformationBlockData = _informationBlockDatas;
            _jsonLDService = jsonLDService;
            _altService = altService;
            SetJsonLD();
            SetHeadings();
            SetParagraphs();
            SetImages();
        }

        private void SetJsonLD()
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

        private void SetHeadings()
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

        private void SetParagraphs()
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

        public void SetImages()
        {
            if (InformationBlockData != null)
            {
                Images = new List<Image>();
                foreach (var image in InformationBlockData.Images)
                {
                    Images.Add(new Image(image, _altService,_jsonLDService));
                }
            }
            else
            {
                Images = null;
            }
        }
    }
}