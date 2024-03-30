﻿using Infrastructure.Models.Data.Carousel.Interfaces;
using Infrastructure.Models.Data.Interface;
using System.Text.Json.Serialization;

namespace Infrastructure.Models.Data.Carousel
{
    public class Carousel : ICarousel, IData
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public List<Image> Images { get; set; }
        public int DisplayOrder { get; set; }
        [JsonIgnore]
        public UIConcreate? UIConcreateType { get; set; }

        public Carousel()
        {
            UIConcreateType = UIConcreate.Carousel;
        }
    }
}
