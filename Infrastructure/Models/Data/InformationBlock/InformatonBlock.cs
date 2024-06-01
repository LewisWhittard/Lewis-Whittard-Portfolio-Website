using Infrastructure.Models.Data.InformationBlock.Interfaces;
using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Image;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.InformationBlock
{
    public class InfomatonBlock : IInformationBlock, IData
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public List<Image>? Images { get; set; }
        public List<Paragraph>? Paragraphs { get; set; }
        public List<Heading>? Headings { get; set; }
        public int? DisplayOrder { get; set; }
        public string GUID { get; set; }
        public string PageName { get; set; }

        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; set; }

        public InfomatonBlock()
        {
            UIConcreteType = UIConcrete.InformationBlock;
        }

        public InfomatonBlock(int id,bool deleted,bool inactive,List<Image>? images,List<Paragraph>? paragraphs,List<Heading>? headings,int displayOrder,string gUID,string pageName)
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
            PageName = pageName;
        }
    }
}
