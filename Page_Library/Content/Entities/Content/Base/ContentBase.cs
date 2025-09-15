using Page_Library.Content.Entities.Content.DTO;
using Page_Library.Content.Entities.Content.Interface;

namespace Page_Library.Content.Entities.Content.Base
{
    public class ContentBase : IContent
    {
        public int ID { get; private set; }

        public string Name { get; private set; }

        public string Path { get; private set; }
        
        public string Type { get; private set; }

        public ContentBase(contentDTO dto)
        {
            ID = dto.ID;
            Name = dto.Name;
            Path = dto.Path;
        }
    }
}
;