using Infrastructure.Models.Data.Interface;
using SEO.Service.AltService;
using SEO.Service.JsonLDService;
using UIFactory.Factory.Concrete.InformationBlock.Interface;
using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Concrete.Shared.Image;

namespace UIFactory.Factory.Concrete.InformationBlock
{
    public class InformationBlock : IInformationBlock, IConcreteUI
    {
        public Infrastructure.Models.Data.InformationBlock.InfomatonBlock InformationBlockData { get; private set; }
        public List<SEO.Model.JsonLD.JsonLDData>? JsonLDDatas { get; private set; }
        public List<Heading>? Headings { get; private set; }
        public List<Paragraph>? Paragraphs { get; private set; }
        public List<Image>? Images { get; private set; }
        public int? DisplayOrder { get; private set; }
        public UIConcrete UIConcreteType { get; private set; }

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
            DisplayOrder = (int)_informationBlockDatas.DisplayOrder;
            UIConcreteType = (UIConcrete)_informationBlockDatas.UIConcreteType;
        }

        private void SetJsonLD()
        {
            if (_jsonLDService != null)
            {
                JsonLDDatas = _jsonLDService.GetBySuperClassUIID(InformationBlockData.UIID, false);
            }
            else
            {
                JsonLDDatas = null;
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