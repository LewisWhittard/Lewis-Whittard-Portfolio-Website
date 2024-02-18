using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMW_Infrastructure.ViewModel.Partials.Image.Interface
{
    public interface IImage
    {
        public string Value { get; set; }
        public string? ItemProp { get; set; }
        public string? Alt {  get; set; }
    }
}
