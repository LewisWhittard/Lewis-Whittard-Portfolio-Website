using LMW_Infrastructure.ViewModel.Partials.Image.Interface;
using LMW_Infrastructure.ViewModel.Partials.Interface;

namespace LMW_Infrastructure.ViewModel.Partials.Image
{
    public class Image : IImage, IPartialStandards
    {
        public string Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? ItemProp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? Alt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetColumnValue()
        {
            throw new NotImplementedException();
        }
    }
}
