using Infrastructure.Models.Data.Card.Interface;
using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Video.Interfaces;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Card
{
    public class Video : IVideo , IData
    {
        public string Source { get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public int DisplayOrder { get; set; }
        [JsonIgnore]
        public UIConcreate? UIConcreateType { get; set; }

        public Video()
        {
            UIConcreateType = UIConcreate.Video;
        }
    }
}
