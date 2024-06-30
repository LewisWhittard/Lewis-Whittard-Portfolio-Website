﻿namespace SEO.Model.Meta.Interface
{
    public interface IMetaData
    {
        int Id { get; }
        Name Name { get; }
        string Content { get; }
        string UIID { get; }
        string? Charset { get; }
        int PageId { get; }
    }
}
