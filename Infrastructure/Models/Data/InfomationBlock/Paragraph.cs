using Infrastructure.Models.Data.InformationBlock.Interfaces;
using Infrastructure.Models.Data.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.InformationBlock
{
    public class Paragraph : IParagraph,IData
    {
        public string Text { get; set; }
        public int? DisplayOrder { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public int InformationBlockid { get; set; }
        public string GUID { get; set; }

        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; set; }

        public Paragraph(string text,int displayOrder,int id, bool deleted,bool inactive,int informationBlockId, string gUID)
        {
            Text = text;
            DisplayOrder = displayOrder;
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            InformationBlockid = informationBlockId;
            GUID = gUID;
            UIConcreteType = UIConcrete.Paragraph;
        }

        public Paragraph()
        {
            UIConcreteType = UIConcrete.Paragraph;
        }
    }
}
