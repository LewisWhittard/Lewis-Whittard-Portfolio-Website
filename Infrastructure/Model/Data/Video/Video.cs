using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Video.Interfaces;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Video
{
    public class Video : IVideo, IData
    {
        public string Source { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Navigation { get; private set; }
        public int Id { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public int? DisplayOrder { get; private set; }
        public string UIId { get; private set; }
        public int PageId { get; private set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; private set; }

        public Video()
        {
            UIConcreteType = UIConcrete.Video;
        }

        public Video(string source, string title, string description, string navigation, int id, bool deleted, bool inactive, int? displayOrder, string uiid, int pageId)
        {
            Source = source;
            Title = title;
            Description = description;
            Navigation = navigation;
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            DisplayOrder = displayOrder;
            UIId = uiid;
            UIConcreteType = UIConcrete.Video;
            PageId = pageId;
        }
    }
}
