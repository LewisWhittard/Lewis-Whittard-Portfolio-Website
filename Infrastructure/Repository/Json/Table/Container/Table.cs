namespace Infrastructure.Repository.Json.Table.Container
{
    public class Table
    {
        public List<Models.Data.Table.Table> Tables { get; set; }

        public Table(List<Models.Data.Table.Table> table)
        {
            Tables = table;
        }
    }
}
