using LMW_Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMW_Infrastructure.ViewModel.Partials.Text.Interface
{
    public interface IText
    {
        public string Value { get; set; }
        public string? ItemProp { get; set; }
        public HTMLContentComponentType HTMLContentComponentType { get; set; }

        string PopulateValue();
        string? PopulateItemProp();
        HTMLContentComponentType PopulateHTMLContentComponentType();
    }
}
