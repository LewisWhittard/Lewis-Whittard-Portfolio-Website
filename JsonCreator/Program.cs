using Infrastructure.Models.Data.Table;
using Infrastructure.Models.Data.Table.Column;
using Infrastructure.Models.Data.Table.Header;
using Newtonsoft.Json;
using System.Reflection.Emit;
using System.Threading.Tasks.Dataflow;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Header Qualification = new Header(0,false,false,0,0, "Qualification");
            Header Result = new Header(1, false, false, 1, 0, "Result");
            Header Year = new Header(2, false, false, 2, 0, "Year");

            Column Qualification0 = new Column(0,false,false, "SoftwareDevelopmentTechnicianLevel3",0,0,0);
            Column Grade0 = new Column(1, false, false, "Pass", 1, 0, 0);
            Column Date0 = new Column(2, false, false, "2018-2020", 2, 0, 0);

            Column Qualification1 = new Column(0, false, false, "BTEC Level 3 Extended Diploma in Creative Media Production (Game Development) (QCF)", 0, 1, 0);
            Column Grade1 = new Column(1, false, false, "Pass", 1, 1, 0);
            Column Date1 = new Column(2, false, false, "2018-2020", 2, 1, 0);

            List<Table> tables = new List<Table>();

            string json = JsonConvert.SerializeObject(tables, Formatting.Indented);

        }
    }
}