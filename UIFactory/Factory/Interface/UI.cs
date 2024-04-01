using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIFactory.Factory.CSHTML.Concreate.Interface;

namespace UIFactory.Factory.Interface
{
    public interface IUI
    {
        public UI? UIType { get; set; }
    }
}
