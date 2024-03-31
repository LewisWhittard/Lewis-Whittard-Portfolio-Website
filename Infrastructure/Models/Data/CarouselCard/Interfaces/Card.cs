﻿namespace Infrastructure.Models.Data.CarouselCard.Interfaces
{
    public interface ICard
    {
        public Image Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Navigation Navigation { get; set; }
    }
}
