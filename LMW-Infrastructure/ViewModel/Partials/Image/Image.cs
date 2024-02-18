﻿using LMW_Infrastructure.Model;
using LMW_Infrastructure.ViewModel.Partials.Image.Interface;
using LMW_Infrastructure.ViewModel.Partials.Interface;

namespace LMW_Infrastructure.ViewModel.Partials.Image
{
    public class Image : IImage, IPartialStandards
    {
        public string Value {get; set;}
        public string? ItemProp { get; set; }
        public string? Alt { get; set; }
        public HTMLContentComponentType? HTMLContentComponentType { get; set; }

        private readonly ContentComponent _contentComponent;
        
        public Image(ContentComponent contentComponent)
        {
            _contentComponent = contentComponent;
            Value = GetValue();
            ItemProp = GetItemProp();
            Alt = GetAlt();
            HTMLContentComponentType = GetHTMLContentComponentType();
        }

        public string GetValue()
        {
            return _contentComponent.Value;
        }

        public string? GetItemProp()
        {
            return _contentComponent.ItemProp;
        }

        public string? GetAlt()
        {
            return _contentComponent.Alt;
        }

        public HTMLContentComponentType? GetHTMLContentComponentType()
        {
            return _contentComponent.HMTLContentComponentType;
        }
    }
}
