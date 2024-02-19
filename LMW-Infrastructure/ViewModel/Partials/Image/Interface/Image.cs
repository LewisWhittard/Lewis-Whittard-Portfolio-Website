using LMW_Infrastructure.Model;
namespace LMW_Infrastructure.ViewModel.Partials.Image.Interface
{
    public interface IImage
    {
        public string? Alt {  get; set; }
        public string Value { get; set; }
        public string? ItemProp { get; set; }
        public HTMLContentComponentType? HTMLContentComponentType { get; set; }
        public string? GetAlt();
        string GetValue();
        string? GetItemProp();
    }
}
