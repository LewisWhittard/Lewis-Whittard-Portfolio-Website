﻿using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Image.Interfaces;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Shared.Image
{
    public class Image : IImage, IData
    {
        public string Source { get; set; }
        public int? DisplayOrder { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public string GUID { get; set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; set; }

        public Image()
        {

        }

        public Image(string source, int displayOrder, int iD, bool deleted, bool inactive, string gUID)
        {
            Source = source;
            DisplayOrder = displayOrder;
            Id = iD;
            Deleted = deleted;
            Inactive = inactive;
            GUID = gUID;
        }
    }
}
