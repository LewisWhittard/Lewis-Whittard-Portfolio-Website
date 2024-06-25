using Infrastructure.Models.Data.Interface;

namespace SEO.Model.Meta.Interface
{
    public class MetaData : IMetaData, IData
    {
        public int Id { get; private set; }
        public Name Name { get; private set; }
        public string Content { get; private set; }
        public string GUID { get; private set; }
        public string? Charset { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public UIConcrete? UIConcreteType { get; private set; }
        public int? DisplayOrder { get; private set; }
        public int PageId{ get; private set; }

        public MetaData(int id, Name name, string content, string? charset, bool deleted, bool inactive, int pageId)
        {
            Id = id;
            Name = name;
            Content = content;
            Charset = charset;
            Deleted = deleted;
            Inactive = inactive;
            UIConcreteType = null;
            PageId = pageId;
        }

        public MetaData()
        {

        }
    }
}
