﻿namespace Infrastructure.Models.Data.InfomationBlock.Interfaces
{
    public interface IHeading
    {
        public string Text { get; set; }
        public int DisplayOrder { get; set; }
        public int InfomationBlockid { get; set; }
    }
}
