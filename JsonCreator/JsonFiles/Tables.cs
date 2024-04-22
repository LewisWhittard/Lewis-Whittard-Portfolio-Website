using Infrastructure.Models.Data.Table;
using Newtonsoft.Json;

namespace JsonCreator.Pages
{
    public class Tables
    {
        private readonly Infrastructure.Repository.Json.Table.Container.Table Container;

        public Tables()
        {
            var Home = Homepage();
            Container = new Infrastructure.Repository.Json.Table.Container.Table(Home);
            var json = JsonConvert.SerializeObject(Container);
        }

        public List<Infrastructure.Models.Data.Table.Table> Homepage()
        {
        }
    }
}
