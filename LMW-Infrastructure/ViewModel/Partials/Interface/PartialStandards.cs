using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMW_Infrastructure.ViewModel.Partials.Interface
{
    public interface IPartialStandards
    {
        public string Value { get; set; }
        public string? ItemProp { get; set; }
        string GetColumnValue();
    }
}
