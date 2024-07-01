using Infrastructure.Models.Data.InformationBlock.Interfaces;
using Infrastructure.Models.Data.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.InformationBlock
{
    public class Paragraph : IParagraph, IData
    {
        public string Text { get; private set; }
        public int? DisplayOrder { get; private set; }
        public int Id { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public int InformationBlockid { get; private set; }
        public string UIId { get; private set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; private set; }

        public Paragraph(string text, int displayOrder, int id, bool deleted, bool inactive, int informationBlockId, string uIId)
        {
            Text = text;
            DisplayOrder = displayOrder;
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            InformationBlockid = informationBlockId;
            UIId = uIId;
            UIConcreteType = UIConcrete.Paragraph;
        }

        public Paragraph()
        {
            UIConcreteType = UIConcrete.Paragraph;
        }
    }
}
