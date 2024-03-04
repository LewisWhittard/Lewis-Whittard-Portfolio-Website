using Infrastructure.Repository.Interfaces.Table;

using Infrastructure.Repository.Json.Table.Container.Interface;

namespace Infrastructure.Repository.Json.Table.Container
{
    public class Table : ITable
    {
        public readonly List<Models.Data.Table.Table> Tables;

        public Table()
        {
            
        }

        public Table(List<Models.Data.Table.Table> tables)
        {
            Tables = tables;
        }
    }
}
