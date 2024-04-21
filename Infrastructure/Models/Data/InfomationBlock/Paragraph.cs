﻿using Infrastructure.Models.Data.InfomationBlock.Interfaces;
using Infrastructure.Models.Data.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.InfomationBlock
{
    public class Paragraph : IParagraph,IData
    {
        public string Text { get; set; }
        public int DisplayOrder { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public int InfomationBlockid { get; set; }
        public string GUID { get; set; }

        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; set; }

        public Paragraph(string text,int displayOrder,int id, bool deleted,bool inactive,int infomationBlockId, string gUID)
        {
            Text = text;
            DisplayOrder = displayOrder;
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            InfomationBlockid = infomationBlockId;
            GUID = gUID;
        }

        public Paragraph()
        {
            
        }
    }
}
