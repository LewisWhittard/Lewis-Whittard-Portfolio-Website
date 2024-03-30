﻿using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Table.Interfaces;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Table
{
    public class Header : IData, IHeader
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public int DisplayOrder { get; set; }
        public int TableID { get; set; }
        public string Value { get; set; }
        [JsonIgnore]
        public UIConcreate? UIConcreateType { get; set; }

        public Header()
        {

        }

        public Header(int id, bool deleted, bool inactive, int displayOrder, int tableID, string value)
        {
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            DisplayOrder = displayOrder;
            TableID = tableID;
            Value = value;
        }
    }
}
