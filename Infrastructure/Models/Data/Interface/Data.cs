﻿using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Interface
{
    public interface IData
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        [JsonIgnore]
        public UIConcreate? UIConcreateType { get; set; }
    }
}
