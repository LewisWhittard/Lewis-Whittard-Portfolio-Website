﻿using UIFactory.Factory.Concreate.CSHTML.Interface;

namespace UIFactory.Factory.Concreate.CSHTML.Page.Interface
{
    public interface IPage
    {
        public string Webpage { get; set; }
        public List<ICSHTML> HTMLs { get; set; }
    }
}