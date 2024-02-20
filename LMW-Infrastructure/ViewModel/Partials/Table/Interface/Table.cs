namespace LMW_Infrastructure.ViewModel.Partials.Table.Interface
{
    public interface ITable
    {
        string Title { get; set; }
        string Headers { get; set; }
        public string Value { get; set; }
        string PopulateTitle();
        string PopulateColumnHeaders();
        string PopulateValue();
    }
}
