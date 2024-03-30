using Infrastructure.Models.Data.InfomationBlock.Interfaces;
using Infrastructure.Models.Data.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.InfomationBlock
{
    public class Image : IImage, IData
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        [JsonIgnore]
        public UIConcreate? UIConcreateType { get; set; }

        public Image()
        {
            
        }
    }
}
