﻿using SEO.Models.Alt.Interface;
using SEO.Models.JsonLD.Interface;
using UIFactory.Factory.CSHTML.Concrete.InformationBlock.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.InformationBlock
{
    public class InfomatonBlock : IInformationBlock, ICSHTML, IJsonLD, IUI
    {
        public Heading Heading { get; set; }
        public List<Image> Images { get; set; }
        public List<Paragraph> Paragraphs { get; set; }
        public List<Heading> Headings { get; set; }
        public int? DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
        public UI? UIType { get; set; }
        public string GUID { get; set; }

        private readonly Infrastructure.Models.Data.InformationBlock.InfomatonBlock _infomatonBlock;
        private readonly List<IAltData> _alt;

        public InfomatonBlock(Infrastructure.Models.Data.InformationBlock.InfomatonBlock infomatonBlock, List<IJsonLDData> JsonLd, List<IAltData> alt)
        {
            _infomatonBlock = infomatonBlock;
            _alt = alt;
            foreach (var item in _infomatonBlock.Images)
            {
                Image image = new Image(item, _alt.Where(x => x.GUID == item.GUID).FirstOrDefault());
                Images.Add(image);
            }
            foreach (var item in _infomatonBlock.Paragraphs)
            {
                Paragraph paragraph = new Paragraph(item);
                Paragraphs.Add(paragraph);
            }
            foreach (var item in _infomatonBlock.Headings)
            {
                Heading heading = new Heading(item);
				Headings.Add(heading);
			}
            DisplayOrder = _infomatonBlock.Id;
            UIType = UI.InformationBlock;
        }

		public List<IUI> ReturnContentsAsListIUI()
		{
			List<IUI> value = new List<IUI>();

            foreach (var item in Images)
            {
                value.Add(item);
            }
            foreach (var item in Paragraphs)
			{
				value.Add(item);
			}
            foreach (var item in Headings)
			{
				value.Add(item);
			}

			return value;
		}
	}
}