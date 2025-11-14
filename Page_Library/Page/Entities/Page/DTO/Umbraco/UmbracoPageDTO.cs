using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Page_Library.Page.Entities.Page.DTO.Umbraco
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class UmbracoPageDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("updateDate")]
        public DateTime UpdateDate { get; set; }

        [JsonProperty("route")]
        public RouteDto Route { get; set; }

        [JsonProperty("properties")]
        public PropertiesDto Properties { get; set; }
    }

    public class RouteDto
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("queryString")]
        public string QueryString { get; set; }

        [JsonProperty("startItem")]
        public StartItemDto StartItem { get; set; }
    }

    public class StartItemDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }

    public class PropertiesDto
    {
        [JsonProperty("metaSeoBlock")]
        public MetaSeoBlockWrapper MetaSeoBlock { get; set; }

        [JsonProperty("clusterContentBlocks")]
        public ClusterContentBlockWrapper ClusterContentBlocks { get; set; }
    }

    public class MetaSeoBlockWrapper
    {
        [JsonProperty("items")]
        public List<MetaSeoBlockItem> Items { get; set; }
    }

    public class MetaSeoBlockItem
    {
        [JsonProperty("content")]
        public MetaSeoBlockContent Content { get; set; }

        [JsonProperty("settings")]
        public object Settings { get; set; }
    }

    public class MetaSeoBlockContent
    {
        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("properties")]
        public MetaSeoBlockDto Properties { get; set; }
    }

    public class MetaSeoBlockDto
    {
        [JsonProperty("metaTitle")]
        public string MetaTitle { get; set; }

        [JsonProperty("metaDescription")]
        public string MetaDescription { get; set; }

        [JsonProperty("metaKeywords")]
        public string MetaKeywords { get; set; }

        [JsonProperty("metaImageId")]
        public int MetaImageId { get; set; }
    }

    public class ClusterContentBlockWrapper
    {
        [JsonProperty("items")]
        public List<ContentBlockItem> Items { get; set; }
    }

    public class ContentBlockItem
    {
        [JsonProperty("content")]
        public ContentBlockDto Content { get; set; }

        [JsonProperty("settings")]
        public object Settings { get; set; }
    }

    public class ContentBlockDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("blockType")]
        public string BlockType { get; set; }

        [JsonProperty("alignment")]
        public string Alignment { get; set; }

        [JsonProperty("headerLevel")]
        public string HeaderLevel { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("linkText")]
        public string LinkText { get; set; }

        [JsonProperty("imageId")]
        public int? ImageId { get; set; }

        [JsonProperty("mediaId")]
        public int? MediaId { get; set; }
    }
}