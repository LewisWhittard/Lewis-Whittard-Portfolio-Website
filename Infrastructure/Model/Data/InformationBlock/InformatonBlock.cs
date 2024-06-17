using Infrastructure.Models.Data.InformationBlock.Interfaces;
using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Image;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.InformationBlock
{
    public class InfomatonBlock : IInformationBlock, IData
    {
        public int Id { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public List<Image>? Images { get; private set; }
        public List<Paragraph>? Paragraphs { get; private set; }
        public List<Heading>? Headings { get; private set; }
        public int? DisplayOrder { get; private set; }
        public string GUID { get; private set; }
        public int PageId { get; private set; }

        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; private set; }

        public InfomatonBlock()
        {
            UIConcreteType = UIConcrete.InformationBlock;
        }

        public InfomatonBlock(int id, bool deleted, bool inactive, List<Image>? images, List<Paragraph>? paragraphs, List<Heading>? headings, int displayOrder, string gUID, int pageId)
        {

            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            Images = images;
            Paragraphs = paragraphs;
            Headings = headings;
            DisplayOrder = displayOrder;
            GUID = gUID;
            UIConcreteType = UIConcrete.InformationBlock;
            PageId = pageId;
        }
    }
}
