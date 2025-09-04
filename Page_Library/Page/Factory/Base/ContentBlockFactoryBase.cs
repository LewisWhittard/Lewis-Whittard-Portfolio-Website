using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.ContentBlock.Interface;
using Page_Library.Page.Factory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Page_Library.Page.Factory.Base
{
    public abstract class ContentBlockFactoryBase : IContentBlockFactory
    {
        public abstract IContentBlock CreateContentBlock(ContentBlockDTO dto, IContent content);
    }
}

