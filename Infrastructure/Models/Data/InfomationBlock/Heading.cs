using Infrastructure.Models.Data.InfomationBlock.Interfaces;
using Infrastructure.Models.Data.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.InfomationBlock
{
    public class Heading : IData, IHeading
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public string Text { get; set; }
        public int DisplayOrder { get; set; }
        public int InfomationBlockid { get; set; }
        [JsonIgnore]
        public UIConcreate? UIConcreateType { get; set; }

        public Heading()
        {
            
        }

        public Heading(int id, bool deleted, bool inactive, string text, int displayOrder, int infomationBlockid)
        {
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            Text = text;
            DisplayOrder = displayOrder;
            InfomationBlockid = infomationBlockid;

        }
    }
}
