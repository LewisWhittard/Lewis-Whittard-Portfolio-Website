using Infrastructure.Models.Data.InformationBlock.Interfaces;
using Infrastructure.Models.Data.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.InformationBlock
{
    public class Heading : IData, IHeading
    {
        public int Id { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public string Text { get; private set; }
        public int? DisplayOrder { get; private set; }
        public int InformationBlockid { get; private set; }
        public string UIID { get; private set; }
        public int Level { get; private set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; private set; }

        public Heading()
        {
            UIConcreteType = UIConcrete.Heading;
        }

        public Heading(int id, bool deleted, bool inactive, string text, int displayOrder, int informationBlockid, string uIId, int level)
        {
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            Text = text;
            DisplayOrder = displayOrder;
            InformationBlockid = informationBlockid;
            UIID = uIId;
            Level = level;
            UIConcreteType = UIConcrete.Heading;
        }
    }
}
