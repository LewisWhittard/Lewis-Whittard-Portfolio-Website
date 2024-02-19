using LMW_Infrastructure.Model;
using LMW_Infrastructure.ViewModel.Partials.Video.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMW_Infrastructure.ViewModel.Partials.Video
{
    public class Video : IVideo
    {
        public string Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public HTMLContentComponentType HTMLContentComponentType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public HTMLContentComponentType PopulateHTMLContentComponentType()
        {
            throw new NotImplementedException();
        }

        public string? PopulateItemProp()
        {
            throw new NotImplementedException();
        }

        public string PopulateValue()
        {
            throw new NotImplementedException();
        }
    }
}
}
