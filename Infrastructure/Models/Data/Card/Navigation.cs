﻿using Infrastructure.Models.Data.Card.Interfaces;
using Infrastructure.Models.Data.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Card
{
    public class Navigation : IData, INavigation
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public string Value { get; set; }
        [JsonIgnore]
        public UIConcreate? UIConcreateType { get; set; }
    }
}
