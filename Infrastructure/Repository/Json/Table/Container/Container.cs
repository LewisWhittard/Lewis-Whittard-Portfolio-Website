using Infrastructure.Repository.Json.Table.Container.Interface;

namespace Infrastructure.Repository.Json.Table.Container
{
    public class Container : IContainer
    {
        public readonly List<Models.Data.Table.Table> Tables;

        public Container()
        {
            
        }

        public Container(List<Models.Data.Table.Table> tables)
        {
            Tables = tables;
        }
    }
}
