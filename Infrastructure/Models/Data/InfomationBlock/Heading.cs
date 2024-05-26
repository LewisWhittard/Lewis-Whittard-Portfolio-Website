using Infrastructure.Models.Data.InformationBlock.Interfaces;
using Infrastructure.Models.Data.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.InformationBlock
{
    public class Heading : IData, IHeading
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public string Text { get; set; }
        public int? DisplayOrder { get; set; }
        public int InformationBlockid { get; set; }
        public string GUID { get; set; }
        public int Level { get; set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; set; }

        public Heading()
        {
            UIConcreteType = UIConcrete.Heading;
        }

        public Heading(int id, bool deleted, bool inactive, string text, int displayOrder, int informationBlockid,string gUID, int level)
        {
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            Text = text;
            DisplayOrder = displayOrder;
            InformationBlockid = informationBlockid;
            GUID = gUID;
            Level = level;
            UIConcreteType = UIConcrete.Heading;
        }
    }
}
