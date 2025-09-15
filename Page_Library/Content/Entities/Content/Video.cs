using Page_Library.Content.Entities.Content.Base;
using Page_Library.Content.Entities.Content.DTO;

namespace Page_Library.Content.Entities.Content
{
    public class Video : ContentBase
    {
        public string Description { get; private set; }

        public Video(contentDTO dto) : base(dto)
        {
            Description = dto.Description;
        }
    }
}
