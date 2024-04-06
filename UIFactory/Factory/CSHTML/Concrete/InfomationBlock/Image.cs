﻿using SEO.Models.Alt.Interface;
using UIFactory.Factory.CSHTML.Concrete.InfomationBlock.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.InfomationBlock
{
    public class Image : IImage, ICSHTML
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public UI? UIType { get; set; }
        public string Alt { get; set; } 
        private readonly Infrastructure.Models.Data.InfomationBlock.Image _image;
        private readonly IAltData _alt;

        public Image(Infrastructure.Models.Data.InfomationBlock.Image Image, IAltData alt)
        {
            _image = Image;
            _alt = alt;
            Source = _image.Source;
            DisplayOrder = _image.DisplayOrder;
            Alt = _alt.Value;
        }
    }
}