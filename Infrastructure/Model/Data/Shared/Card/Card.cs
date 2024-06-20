﻿using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Card.Interfaces;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Shared.Card
{
    public class Card : ICard, IData
    {
        public Image.Image Image { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Navigation { get; private set; }
        public int Id { get; private set; }
        public bool Deleted { get; private set; }
        public bool Inactive { get; private set; }
        public int? DisplayOrder { get; private set; }
        public string GUID { get; private set; }
        public int? PageId { get; private set; }
        [JsonIgnore]
        public UIConcrete? UIConcreteType { get; private set; }

        public Card(Image.Image image, string title, string description, string navigation, int id, bool deleted, bool inactive, int displayOrder, string gUID, int? pageId)
        {
            Image = image;
            Title = title;
            Description = description;
            Navigation = navigation;
            Id = id;
            Deleted = deleted;
            Inactive = inactive;
            DisplayOrder = displayOrder;
            GUID = gUID;
            UIConcreteType = UIConcrete.Card;
            PageId = pageId;
        }

        public Card()
        {
            UIConcreteType = UIConcrete.Card;
        }
    }
}