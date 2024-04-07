﻿using Infrastructure.Models.Data.Interface;
using Infrastructure.Repository.Interface;

namespace Infrastructure.Service.Page.Interface
{
    public interface IPageService
    {
        public Models.Data.Page.Page GetByPageName(string PageName);
        public List<IData> GetByPageNameAsIDataList(string PageName);
    }
}
