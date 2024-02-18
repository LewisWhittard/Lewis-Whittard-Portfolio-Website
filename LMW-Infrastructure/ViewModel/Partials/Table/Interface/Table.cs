using LMW_Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMW_Infrastructure.ViewModel.Partials.Table.Interface
{
    public interface ITable
    {
        string Title { get; set; }
        string Headers { get; set; }
        string Values { get; set; }
        string GetTitle();
        string GetColumnHeaders();
        string GetColumnValues();
    }
}
