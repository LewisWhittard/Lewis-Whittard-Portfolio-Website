using Page_Library.Page.Entities.ContentBlock.Base;
using Page_Library.Page.Entities.ContentBlock.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Library.Page.Entities.ContentBlock
{
    public class HeaderBlock : ContentBlockBase
    {
        public string Level { get; private set; }  // e.g., "H1", "H2", "H3"
        public string Text { get; private set; }

        public HeaderBlock(ContentBlockDTO dto) : base(dto)
        {
            Level = dto.Level;
            Text = dto.Text;
        }
    }


}
