namespace SEO.Models.Meta.Interface
{
    public interface IMetaData
    {
        int Id { get; }
        Name Name { get; }
        string Content { get; }
        string GUID { get; }
        string? Charset { get; }
        string PageName { get; }
    }
}
