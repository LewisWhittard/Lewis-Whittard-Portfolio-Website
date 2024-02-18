namespace LMW_Infrastructure.ViewModel.Partials.Interface
{
    public interface IPartialStandards
    {
        public string Value { get; set; }
        public string? ItemProp { get; set; }
        
        string GetValue();
        string? GetItemProp();
    }
}
