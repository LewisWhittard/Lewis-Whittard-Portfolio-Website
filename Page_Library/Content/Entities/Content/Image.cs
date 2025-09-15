using Page_Library.Content.Entities.Content.Base;
using Page_Library.Content.Entities.Content.DTO;

namespace Page_Library.Content.Entities.Content
{
    public class Image : ContentBase
    {
        public string Alt { get; private set; }

        public Image(contentDTO dto) : base(dto)
        {
            Alt = dto.Alt;
        }
    }
}
