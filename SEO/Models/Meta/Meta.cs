using Infrastructure.Models.Data.Interface;

namespace SEO.Models.Meta.Interface
{
    public class MetaData : IMetaData, IData
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public string Content { get; set; }
        public string GUID { get; set; }
        public string? Charset { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public UIConcrete? UIConcreteType { get; set; }
        public int? DisplayOrder { get; set; }
        public string PageName { get; set; }

        public MetaData(int id, Name name, string content, string guid, string? charset, bool deleted, bool inactive, UIConcrete? uiConcreteType, int? displayOrder, string pageName)
        {
            Id = id;
            Name = name;
            Content = content;
            GUID = guid;
            Charset = charset;
            Deleted = deleted;
            Inactive = inactive;
            UIConcreteType = uiConcreteType;
            DisplayOrder = displayOrder;
            PageName = pageName;
        }
    }
}
